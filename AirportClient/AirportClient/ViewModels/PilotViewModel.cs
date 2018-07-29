using AirportClient.Infrastructure;
using AirportClient.Models;
using AirportClient.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace AirportClient.ViewModels
{
    public class PilotViewModel : BaseViewModel, INotifyPropertyChanged
    {

        private ObservableCollection<Pilot> entities;
        private Pilot entity;
        private Pilot selectedEntity;
        int entityID = 0;

        public ICommand NewEntity { get; private set; }
        public ICommand AddEntity { get; private set; }
        public ICommand UpdateEntity { get; private set; }
        public ICommand DeleteEntity { get; private set; }

        public PilotService Service { get; private set; }

        public PilotViewModel()
        {
            Service = new PilotService();
            NewEntity = new RoutedCommand(UpdateForm);
            AddEntity = new RoutedCommand(Create);
            UpdateEntity = new RoutedCommand(Update);
            DeleteEntity = new RoutedCommand(Delete);
            Load();
            Entity = new Pilot();

        }

        public ObservableCollection<Pilot> Collection
        {
            get { return entities; }
            set
            {
                entities = value;
                OnPropertyChanged("Collection");
            }
        }

        public Pilot Entity
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

        public Pilot SelectedEntity
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
            Entity = new Pilot();
        }

        void Load()
        {
            Collection = new ObservableCollection<Pilot>(Service.Load());
        }

        async void Delete(object o)
        {
            await Service.delete(Entity.Id);
            Entity = new Pilot();
            Load();
        }

        async void Update(object o)
        {
            await Service.Update(Entity);
            Entity = new Pilot();
            Load();
        }

        async void Create(object o)
        {
            await Service.Create(Entity);
            Entity = new Pilot();
            Load();

        }
    }
}

