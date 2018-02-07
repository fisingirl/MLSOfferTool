using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore.Internal;

// ReSharper disable once CheckNamespace
namespace MLSOfferTool.DataAccess
{
    public class DataServiceBase<TC> : IDisposable
        where TC : DbContext, new()
    {
        private TC _DataContext;

        public virtual TC DataContext
        {
            get
            {
                if (this._DataContext == null)
                {
                    this._DataContext = new TC();
                    this._AllowSerialization = true;
                }

                return this._DataContext;
            }
        }

        public void Save()
        {
            this._DataContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._Disposed)
            {
                if (disposing)
                {
                    this._DataContext.Dispose();
                }
            }
            this._Disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _AllowSerialization { get; set; }
        private bool _Disposed = false;
    }
}