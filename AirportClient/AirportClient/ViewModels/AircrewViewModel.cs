using AirportClient.Infrastructure;
using AirportClient.Models;
using AirportClient.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace AirportClient.ViewModels
{
    public class AircrewViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private ObservableCollection<Crew> entities;
        private Crew entity;
        private Crew selectedEntity;
        int entityID = 0;

        public ICommand NewEntity { get; private set; }
        public ICommand AddEntity { get; private set; }
        public ICommand UpdateEntity { get; private set; }
        public ICommand DeleteEntity { get; private set; }

        public CrewService Service { get; private set; }

        public AircrewViewModel()
        {
            Service = new CrewService();
            NewEntity = new RoutedCommand(UpdateForm);
            AddEntity = new RoutedCommand(Create);
            UpdateEntity = new RoutedCommand(Update);
            DeleteEntity = new RoutedCommand(Delete);
            Load();
            Entity = new Crew();

        }

        public ObservableCollection<Crew> Collection
        {
            get { return entities; }
            set
            {
                entities = value;
                OnPropertyChanged("Collection");
            }
        }

        public Crew Entity
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

        public Crew SelectedEntity
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
            Entity = new Crew();
        }

        void Load()
        {
            Collection = new ObservableCollection<Crew>(Service.Load());
        }

        async void Delete(object o)
        {
            await Service.delete(Entity.Id);
            Entity = new Crew();
            Load();
        }

        async void Update(object o)
        {
            await Service.Update(Entity);
            Entity = new Crew();
            Load();
        }

        async void Create(object o)
        {
            await Service.Create(Entity);
            Entity = new Crew();
            Load();

        }
    }
}
