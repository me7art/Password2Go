using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password2Go.FluxStores
{
    public enum UpdatedActionEnum
    {
        None,
        Add,
        Update,
        Delete
    }

    public class UpdatedArgs<T> : EventArgs
    {
        public UpdatedActionEnum UpdatedAction { get; private set; }

        public T[] Items;
        public UpdatedArgs(UpdatedActionEnum updatedAction, params T[] Items)
        {
            this.UpdatedAction = updatedAction;
            this.Items = Items;
        }
    }

    public interface IReciever<T>
    {
        void StoreUpdateHandler(object sender, UpdatedArgs<T> a);
    }

    public delegate void StoreUpdatedEventHandler<T>(object sender, UpdatedArgs<T> a);

    public class CommonStore<T>
    {
        event StoreUpdatedEventHandler<T> StoreUpdated;

        public void Subscribe(IReciever<T> reciever)
        {
            StoreUpdated += reciever.StoreUpdateHandler;
        }

        public void Unsubscripbe(IReciever<T> reciever)
        {
            StoreUpdated -= reciever.StoreUpdateHandler;
        }

        public void Add(object sender, params T[] items)
        {
            StoreUpdated?.Invoke(sender,
                new UpdatedArgs<T>(UpdatedActionEnum.Add, items));
        }

        public void Update(object sender, T items)
        {
            StoreUpdated?.Invoke(sender,
                new UpdatedArgs<T>(UpdatedActionEnum.Update, items));
        }

        public void Delete(object sender, T items)
        {
            StoreUpdated?.Invoke(sender,
                new UpdatedArgs<T>(UpdatedActionEnum.Delete, items));
        }
    }
}
