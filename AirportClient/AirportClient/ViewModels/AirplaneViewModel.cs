using AirportClient.Infrastructure;
using AirportClient.Models;
using AirportClient.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace AirportClient.ViewModels
{
    public class AirplaneViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private ObservableCollection<Airplane> entities;
        private Airplane entity;
        private Airplane selectedEntity;
        int entityID = 0;

        public ICommand NewEntity { get; private set; }
        public ICommand AddEntity { get; private set; }
        public ICommand UpdateEntity { get; private set; }
        public ICommand DeleteEntity { get; private set; }

        public PlaneService Service { get; private set; }

        public AirplaneViewModel()
        {
            Service = new PlaneService();
            NewEntity = new RoutedCommand(UpdateForm);
            AddEntity = new RoutedCommand(Create);
            UpdateEntity = new RoutedCommand(Update);
            DeleteEntity = new RoutedCommand(Delete);
            Load();
            Entity = new Airplane();

        }

        public ObservableCollection<Airplane> Collection
        {
            get { return entities; }
            set
            {
                entities = value;
                OnPropertyChanged("Collection");
            }
        }

        public Airplane Entity
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

        public Airplane SelectedEntity
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
            Entity = new Airplane();
        }

        void Load()
        {
            Collection = new ObservableCollection<Airplane>(Service.Load());
        }

        async void Delete(object o)
        {
            await Service.delete(Entity.Id);
            Entity = new Airplane();
            Load();
        }

        async void Update(object o)
        {
            await Service.Update(Entity);
            Entity = new Airplane();
            Load();
        }

        async void Create(object o)
        {
            await Service.Create(Entity);
            Entity = new Airplane();
            Load();

        }

    }
}
