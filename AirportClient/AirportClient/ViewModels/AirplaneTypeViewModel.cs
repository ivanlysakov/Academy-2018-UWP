using AirportClient.Infrastructure;
using AirportClient.Models;
using AirportClient.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace AirportClient.ViewModels
{
    public class AirplaneTypeViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private ObservableCollection<AirplaneType> entities;
        private AirplaneType entity;
        private AirplaneType selectedEntity;
        int entityID = 0;

        public ICommand NewEntity { get; private set; }
        public ICommand AddEntity { get; private set; }
        public ICommand UpdateEntity { get; private set; }
        public ICommand DeleteEntity { get; private set; }

        public PlaneTypeService Service { get; private set; }

        public AirplaneTypeViewModel()
        {
            Service = new PlaneTypeService();
            NewEntity = new RoutedCommand(UpdateForm);
            AddEntity = new RoutedCommand(Create);
            UpdateEntity = new RoutedCommand(Update);
            DeleteEntity = new RoutedCommand(Delete);
            Load();
            Entity = new AirplaneType();

        }

        public ObservableCollection<AirplaneType> Collection
        {
            get { return entities; }
            set
            {
                entities = value;
                OnPropertyChanged("Collection");
            }
        }

        public AirplaneType Entity
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

        public AirplaneType SelectedEntity
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
            Entity = new AirplaneType();
        }

        void Load()
        {
            Collection = new ObservableCollection<AirplaneType>(Service.Load());
        }

        async void Delete(object o)
        {
            await Service.delete(Entity.Id);
            Entity = new AirplaneType();
            Load();
        }

        async void Update(object o)
        {
            await Service.Update(Entity);
            Entity = new AirplaneType();
            Load();
        }

        async void Create(object o)
        {
            await Service.Create(Entity);
            Entity = new AirplaneType();
            Load();

        }
    }
}
