using AirportClient.Infrastructure;
using AirportClient.Models;
using AirportClient.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace AirportClient.ViewModels
{
    public class TicketViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private ObservableCollection<Ticket> entities;
        private Ticket entity;
        private Ticket selectedEntity;
        int entityID = 0;

        public ICommand NewEntity { get; private set; }
        public ICommand AddEntity { get; private set; }
        public ICommand UpdateEntity { get; private set; }
        public ICommand DeleteEntity { get; private set; }

        public TicketService Service { get; private set; }

        public TicketViewModel()
        {
            Service = new TicketService();
            NewEntity = new RoutedCommand(UpdateForm);
            AddEntity = new RoutedCommand(Create);
            UpdateEntity = new RoutedCommand(Update);
            DeleteEntity = new RoutedCommand(Delete);
            Load();
            Entity = new Ticket();

        }

        public ObservableCollection<Ticket> Collection
        {
            get { return entities; }
            set
            {
                entities = value;
                OnPropertyChanged("Collection");
            }
        }

        public Ticket Entity
        {
            get { return entity; }
            set
            {
                entity = value;
                if (Entity != null)
                {
                    EntityId = entity.Id;
                }
                OnPropertyChanged("Entity");
            }
        }

        public Ticket SelectedEntity
        {
            get { return selectedEntity; }
            set
            {
                selectedEntity = value;
                Entity = selectedEntity;
                OnPropertyChanged("Entity");
            }
        }

        public int EntityId
        {
            get { return entityID; }
            set
            {
                entityID = value;
                OnPropertyChanged("EntityId");
            }
        }

        void UpdateForm(object o)
        {
            Entity = new Ticket();
        }

        void Load()
        {
            Collection = new ObservableCollection<Ticket>(Service.Load());
        }

        async void Delete(object o)
        {
            await Service.delete(Entity.Id);
            Entity = new Ticket();
            Load();
        }

        async void Update(object o)
        {
            await Service.Update(Entity);
            Entity = new Ticket();
            Load();
        }

        async void Create(object o)
        {
            await Service.Create(Entity);
            Entity = new Ticket();
            Load();

        }
    }
}
