/*
 * ITSE 1430
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {

        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        public Product Add ( Product product )
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product is null");
            ObjectValidator.Validate(product);

            // Product must be unique
            try
            {
                var existing = FindByName(product.Name);
                if (existing != null)
                    throw new InvalidOperationException("Product must be unique");

                return AddCore(product);
            } catch (InvalidOperationException)
            {
                //Rethrow exception
                throw;
            } catch (Exception e)
            {
                //Rewrite exception with original exception as the inner exception
                throw new InvalidOperationException("Error adding movie", e);
            };
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        public Product Get ( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");

            return GetCore(id);
        }

        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        public IEnumerable<Product> GetAll () => GetAllCore() ?? Enumerable.Empty<Product>();
        
        /// <summary>Removes the product.</summary>
        /// <param name="id">The product to remove.</param>
        public void Remove ( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");

            RemoveCore(id);
        }
        
        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        public Product Update ( int id, Product product )
        {

            if (product == null)
                throw new ArgumentNullException(nameof(product), "Protected is null");

            ObjectValidator.Validate(product);

            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");

            var existing = FindById(id);
            if (existing == null)
                throw new ArgumentException("Product not found", nameof(id));

            //Movie names must be unique
            var sameName = FindByName(product.Name);
            if (sameName != null && sameName.Id != id)
                throw new InvalidOperationException("Product must be unique");
            //return "Movie must be unique";

            UpdateCore(id, product);

            return null;
        }

        #region Protected Members

        protected abstract Product GetCore( int id );

        protected abstract IEnumerable<Product> GetAllCore();

        protected abstract void RemoveCore( int id );

        protected abstract Product UpdateCore( Product existing, Product newItem );

        protected abstract Product AddCore( Product product );
        #endregion

        protected abstract void UpdateCore ( int id, Product product );

        protected abstract Product FindByName ( string title );

        protected abstract Product FindById ( int id );
    }
}
