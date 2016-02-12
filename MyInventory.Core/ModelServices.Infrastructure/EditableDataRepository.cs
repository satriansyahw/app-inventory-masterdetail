using System;
using System.Collections;
using System.ComponentModel;
using System.ServiceModel.DomainServices.Client;

namespace Intersoft.ClientUI.Samples.UXGridView.ModelServices
{
    /// <summary>
    /// Represents a generic data repository that provides data access and transaction functionality.
    /// </summary>
    public class EditableDataRepository<T> : DataRepository<T>, IEditableDataRepository<T> where T : Entity, new()
    {
        /// <summary>
        /// Initializes a new instance of <see cref="EditableDataRepository"/> class.
        /// </summary>
        /// <param name="context">A <see cref="DomainContext"/> that provides access to all functionality of the data service.</param>
        public EditableDataRepository(DomainContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Create a new entity based on the type of the data repository.
        /// </summary>
        /// <returns>Returns a newly created entity.</returns>
        public virtual T Create()
        {
            return new T();
        }

        /// <summary>
        /// Insert the specified entity to the data repository.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        public virtual void Insert(T entity)
        {
            this.EntitySet.Add(entity);
        }

        /// <summary>
        /// Delete one or more entity in the specified collection from the data repository.
        /// </summary>
        /// <param name="entities">A collection of entity to delete.</param>
        public virtual void Delete(IList entities)
        {
            foreach (T o in entities)
            {
                this.Delete(o);
            }
        }

        /// <summary>
        /// Delete the specified entity from the data repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public virtual void Delete(T entity)
        {
            this.EntitySet.Remove(entity as Entity);
        }

        /// <summary>
        /// Reject the changes which have been made to the entity.
        /// </summary>
        /// <param name="entity">The entity of which changes to reject.</param>
        public virtual void RejectChanges()
        {
            this.Context.RejectChanges();
        }

        /// <summary>
        /// Save all changes made to the data repository since it is first loaded.
        /// </summary>
        /// <param name="onSuccess">The callback to invoke when the save operation succeeded.</param>
        /// <param name="onError">The callback to invoke when the save operation failed.</param>
        public virtual void SaveChanges(Action onSuccess, Action<Exception> onError)
        {
            this.Context.SubmitChanges
            (
                op =>
                {
                    if (op.IsComplete)
                    {
                        if (op.HasError)
                        {
                            // handle error
                            op.MarkErrorAsHandled();
                            onError(op.Error);
                        }
                        else
                        {
                            onSuccess();
                        }
                    }
                },
                null
            );
        }

        /// <summary>
        /// Validate the specified entity.
        /// </summary>
        /// <param name="entity">The entity to validate.</param>
        public virtual void Validate(T entity)
        {
        }

        /// <summary>
        /// Reject all changes made to the data repository since it is first loaded.
        /// </summary>
        public virtual void RejectChanges(T entity)
        {
            IRevertibleChangeTracking revertible = (IRevertibleChangeTracking)entity;
            revertible.RejectChanges();

            if (((Entity)entity).EntityState == EntityState.New)
            {
                // RIA requires the entity to be removed for new entity
                this.Delete(entity);
            }
        }
    }
}
