namespace PointMappingExample.ViewModel
{
    using System.Windows.Input;
    using System.ComponentModel;
    using System.Collections.Generic;

    using Mastercam.Database;

    using PointMappingExample.Services;
    using PointMappingExample.Commands;
    using System.Runtime.CompilerServices;
    using Mastercam.Math;
    using System.Windows;

    public class MainViewViewModel : INotifyPropertyChanged
    {
        #region Private Fields

        private readonly IMastercamService mastercamService;

        private Point3D selectedPoint;

        private double selectedPointX;

        private double selectedPointY;

        private double selectedPointZ;

        private List<MCView> views;

        private MCView selectedView;

        private Point3D mappedPoint;

        private double mappedPointX;

        private double mappedPointY;

        private double mappedPointZ;

        #endregion

        #region Public Properties

        public Point3D SelectedPoint
        {
            get => this.selectedPoint;

            set
            {
                this.selectedPoint = value;
                this.MapPoint();
                OnPropertyChanged();
            }
        }

        public double SelectedPointX
        {
            get => this.selectedPointX;

            set
            {
                this.selectedPointX = value;
                OnPropertyChanged();
            }
        }

        public double SelectedPointY
        {
            get => this.selectedPointY;

            set
            {
                this.selectedPointY = value;
                OnPropertyChanged();
            }
        }

        public double SelectedPointZ
        {
            get => this.selectedPointZ;

            set
            {
                this.selectedPointZ = value;
                OnPropertyChanged();
            }
        }

        public List<MCView> Views
        {
            get => this.views;

            set
            {
                this.views = value;
                OnPropertyChanged();
            }
        }

        public MCView SelectedView
        {
            get => this.selectedView;

            set
            {
                this.selectedView = value;
                this.MapPoint();
                OnPropertyChanged();
            }
        }

        public double MappedPointX
        {
            get => this.mappedPointX;

            set
            {
                this.mappedPointX = value;
                OnPropertyChanged();
            }
        }

        public double MappedPointY
        {
            get => this.mappedPointY;

            set
            {
                this.mappedPointY = value;
                OnPropertyChanged();
            }
        }

        public double MappedPointZ
        {
            get => this.mappedPointZ;

            set
            {
                this.mappedPointZ = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Construction

        public MainViewViewModel(IMastercamService mastercamService)
        {
            this.mastercamService = mastercamService;

            this.SelectPointCommand = new DelegateCommand(this.OnSelectPointCommand);

            this.Views = mastercamService.GetViews();

            this.SelectedView = Views[0];
    }

        #endregion

        #region Commands

        public ICommand SelectPointCommand { get; }

        #endregion

        #region Private Methods     

        private void OnSelectPointCommand(object parameter)
        {
            var view = (Window)parameter;

            view?.Hide();

            SelectedPoint = mastercamService.SelectSinglePoint();

            SelectedPointX = selectedPoint.x;
            SelectedPointY = selectedPoint.y;
            SelectedPointZ = selectedPoint.z;

            mastercamService.ClearPrompt();

            view?.ShowDialog();
        }

        private void MapPoint()
        {
            mappedPoint = mastercamService.MapPoint(SelectedPoint, SelectedView.ViewMatrix);

            MappedPointX = mappedPoint.x;
            MappedPointY = mappedPoint.y;
            MappedPointZ = mappedPoint.z;
        }

        #endregion

        #region Notify Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        #endregion
    }

}