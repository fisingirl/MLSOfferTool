using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

// ReSharper disable once CheckNamespace

namespace MLSOfferTool.Helpers
{
    public class FakeDbSet<T> : IDbSet<T>
        where T : class
    {
        private readonly HashSet<T> _Data;
        private readonly IQueryable _Query;

        public FakeDbSet(IEnumerable<T> startData)
        {
            this.GetKeyProperties();
            this._Data = startData != null ? new HashSet<T>(startData) : new HashSet<T>();
            this._Query = this._Data.AsQueryable();
        }

        public FakeDbSet()
            : this(null)
        {
        }

        public ObservableCollection<T> Local { get { return new ObservableCollection<T>(this._Data); } }

        public Type ElementType { get { return this._Query.ElementType; } }

        public Expression Expression { get { return this._Query.Expression; } }

        public IQueryProvider Provider { get { return this._Query.Provider; } }

        private IList<PropertyInfo> _KeyProperties { get; set; }

        public virtual T Find(params object[] keyValues)
        {
            if (keyValues.Length != this._KeyProperties.Count)
            {
                throw new ArgumentException("Incorrect number of keys passed to find method");
            }

            var keyQuery = this.AsQueryable();
            for (var i = 0; i < keyValues.Length; i++)
            {
                var x = i; // nested linq
                keyQuery = keyQuery.Where(entity => this._KeyProperties[x].GetValue(entity, null).Equals(keyValues[x]));
            }

            return keyQuery.SingleOrDefault();
        }

        public T Add(T entity)
        {
            var id = this.GetIntegerIdentity(entity);
            if (id > 0)
            {
                //  look to see if we already have the item (by its id value), and if so, remove the old one before adding this one, to simulate the replace which is how real DbSet would act
                var realEntity = this.Find(id);
                if (realEntity != null)
                {
                    this.Remove(realEntity);
                }
            }
            else
            {
                this.GenerateId(entity);
            }
            this._Data.Add(entity);
            return entity;
        }

        public T Remove(T entity)
        {
            this._Data.Remove(entity);
            return entity;
        }

        public T Attach(T entity)
        {
            this._Data.Add(entity);
            return entity;
        }

        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "Microsoft suppresses this warning, too.")]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._Data.GetEnumerator();
        }

        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "Microsoft suppresses this warning, too.")]
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this._Data.GetEnumerator();
        }

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public TDerivedEntity Create<TDerivedEntity>()
            where TDerivedEntity : class, T
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public void Detach(T entity)
        {
            this._Data.Remove(entity);
        }

        private void AddKeyPropertyIfDoesntExist(PropertyInfo propertyInfo)
        {
            if (this._KeyProperties.Any(pi => (String.Compare(propertyInfo.Name, pi.Name, StringComparison.OrdinalIgnoreCase) == 0)) == false)
            {
                this._KeyProperties.Add(propertyInfo);
            }
        }

        /// <summary>
        ///   Look at a type (and its metadata classes) looking for a property marked with [Key] attribute,
        ///   or a property specifically named "Id" that is an integer
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "t", Justification = "The act of accessing the metadataClassType has side effects we want.")]
        private void GetKeyProperties()
        {
            this._KeyProperties = new List<PropertyInfo>();
            foreach (var prop1 in typeof(T).GetProperties())
            {
                if (prop1.GetCustomAttributes(true).OfType<KeyAttribute>().Any())
                {
                    this.AddKeyPropertyIfDoesntExist(prop1);
                }
            }

            //  check metadata classes
            var metaAttr = (MetadataTypeAttribute[])typeof(T).GetCustomAttributes(typeof(MetadataTypeAttribute), true);
            foreach (var attr in metaAttr)
            {
#pragma warning disable 168
                // ReSharper disable once UnusedVariable
                var t = attr.MetadataClassType;
#pragma warning restore 168
                foreach (var prop2 in typeof(T).GetProperties())
                {
                    //  If the property is named Id, we assume its the Key!
                    if ((String.Compare("Id", prop2.Name, StringComparison.OrdinalIgnoreCase) == 0) && (prop2.PropertyType == typeof(int)))
                    {
                        this.AddKeyPropertyIfDoesntExist(prop2);
                        break;
                    }

                    if (prop2.GetCustomAttributes(true).OfType<KeyAttribute>().Any() == true)
                    {
                        this.AddKeyPropertyIfDoesntExist(prop2);
                    }
                }
            }

            //  we didn't find any metadata answer, so lets fall back to looking for something named Id just on the class itself
            foreach (var prop3 in typeof(T).GetProperties())
            {
                //  If the property is named Id, we assume its the Key!
                if ((String.Compare("Id", prop3.Name, StringComparison.OrdinalIgnoreCase) == 0) && (prop3.PropertyType == typeof(int)))
                {
                    this.AddKeyPropertyIfDoesntExist(prop3);
                    break;
                }
            }
        }

        private void GenerateId(T entity)
        {
            //  dbset.Add() acts like this: Entities that are already in the context in some other state will have their state set to Added. Add is a no-op if the entity is already in the context in the Added state.

            // If non-composite integer key
            if (this._KeyProperties.Count == 1 && this._KeyProperties[0].PropertyType == typeof(int))
            {
                var id = (int)this._KeyProperties[0].GetValue(entity);
                if (id == 0)
                {
                    var maxpreviousidentity = 0;
                    if (this._Data.Count > 0)
                    {
                        maxpreviousidentity = this._Data.Max(en => (int)this._KeyProperties[0].GetValue(en));
                    }
                    this._KeyProperties[0].SetValue(entity, maxpreviousidentity + 1, null);
                }
            }
        }

        private int? GetIntegerIdentity(T entity)
        {
            if (this._KeyProperties.Count == 1 && this._KeyProperties[0].PropertyType == typeof(int))
            {
                var id = (int)this._KeyProperties[0].GetValue(entity);
                if (id > 0)
                {
                    return id;
                }
            }
            return null;
        }
    }
}