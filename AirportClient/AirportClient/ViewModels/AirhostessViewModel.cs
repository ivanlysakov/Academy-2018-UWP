using AirportClient.Infrastructure;
using AirportClient.Models;
using AirportClient.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace AirportClient.ViewModels
{
    public class AirhostessViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private ObservableCollection<Hostess> entities;
        private Hostess entity;
        private Hostess selectedEntity;
        int entityID = 0;

        public ICommand NewEntity { get; private set; }
        public ICommand AddEntity { get; private set; }
        public ICommand UpdateEntity { get; private set; }
        public ICommand DeleteEntity { get; private set; }

        public HostessService Service { get; private set; }
        
        public AirhostessViewModel()
        {
            Service = new HostessService();
            NewEntity = new RoutedCommand(UpdateForm);
            AddEntity = new RoutedCommand(Create);
            UpdateEntity = new RoutedCommand(Update);
            DeleteEntity = new RoutedCommand(Delete);
            Load();
            Entity = new Hostess();

        }
        
        public ObservableCollection<Hostess> Collection
        {
            get { return entities; }
            set
            {
                entities = value;
                OnPropertyChanged("Collection");
            }
        }

        public Hostess Entity
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

        public Hostess SelectedEntity
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
            Entity = new Hostess();
        }

        async void Load()
        {
            Collection = new ObservableCollection<Hostess>(await Service.Load());
        }

        async void Delete(object o)
        {
            await Service.Delete(Entity.Id);
            Entity = new Hostess();
            Load();
        }

        async void Update(object o)
        {
            await Service.Update(Entity);
            Entity = new Hostess();
            Load();
        }
        
        async void Create(object o)
        {
            await Service.Create(Entity);
            Entity = new Hostess();
            Load();

        }
    }
}

