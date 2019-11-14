using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using FDR.Repositories.Implement;
using FDR.Repositories.Interface;
using System.Windows.Input;
using System.Windows;

namespace FDR.ViewModel
{
    public class PersonViewModel : BaseViewModel
    {
        private IBase<GiangVien> _repondGV = null;
        private IBase<SinhVien> _repondSV = null;
        private ObservableCollection<GiangVien> _listGiangVien;
        private ObservableCollection<SinhVien> _listSinhVien;
        private GiangVien _selectedTea;
        private SinhVien _selectedStu;

        private string _maGiangVien;
        private string _hoTen;
        private string _email;
        private string _hocVi;
        private string _passwords;
        private string _role;
        public string MaGiangVien
        {
            get => _maGiangVien;
            set
            {
                if (value != null)
                {
                    _maGiangVien = value;
                    OnPropertyChanged("MaGiangVien");
                }
            }
        }
        public string HoTen
        {
            get => _hoTen;
            set
            {
                if (value != null)
                {
                    _hoTen = value;
                    OnPropertyChanged("HoTen");
                }
            }
        }
        public string Email
        {
            get => _email;
            set
            {

                if (value != null)
                {
                    _email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public string HocVi
        {
            get => _hocVi;
            set
            {
                if (value != null)
                {
                    _hocVi = value; ;
                    OnPropertyChanged("HocVi");
                }
            }
        }
        public string Passwords
        {
            get => _passwords;
            set
            {
                if (value != null)
                {
                    _passwords = value; ;
                    OnPropertyChanged("Passwords");
                }
            }
        }
        public string Role
        {
            get => _role;
            set
            {
                
                {
                    _role = value; ;
                    OnPropertyChanged("Role");
                }
            }
        }

        private string _maSinhVien;
        private string _ten;
        private string _hoDem;
        private string _lop;
        public string MaSinhVien
        {
            get => _maSinhVien;
            set
            {
                if (value != null)
                {
                     _maSinhVien = value;
                    OnPropertyChanged("MaSinhVien");
                }
            }
            
        }
        public string TenSinhVien
        {
            get => _ten;
            set
            {         
                if (value != null)
                {
                    _ten = value;
                    OnPropertyChanged("TenSinhVien");
                }
            }
        }
         
        public string HoDem
        {
            get => _hoDem;
            set
            { 
                if (value != null)
                {
                    _hoDem = value;
                    OnPropertyChanged("HoDem");
                }
            }
        }
        public string Lop
        { get => _lop;
            set
            {
                if (value != null)
                {
                    _lop = value;
                    OnPropertyChanged("Lop");
                }
            }
        }
        public ObservableCollection<GiangVien> ListTea
        {
            get => _listGiangVien;
            set
            {
                if (value != null)
                {
                    _listGiangVien = value;
                    OnPropertyChanged("ListTea");
                }
            }
        }
            public ObservableCollection<SinhVien> ListStu
        {
            get => _listSinhVien;
            set
            {
                if (value != null)
                {
                    _listSinhVien = value;
                    OnPropertyChanged("ListStu");
                }
            }
        }
        public GiangVien SelectedTea
        {
            get => _selectedTea;
            set
            {
                if (value != null)
                {
                    _selectedTea = value;
                    OnPropertyChanged("SelectedTea");

                    MaGiangVien = _selectedTea.MaGiangVien;
                    HoTen = _selectedTea.HoTen;
                    Email = _selectedTea.Email;
                    HocVi = _selectedTea.HocVi;
                    Passwords = _selectedTea.Passwords;
                    Role = _selectedTea.Role.ToString();

                }
            }
        }
        public SinhVien SelectedStu
        {
            get => _selectedStu;
            set
            {
                if (value != null)
                {
                    _selectedStu = value;
                    OnPropertyChanged("SelectedStu");

                    MaSinhVien = _selectedStu.MaSinhVien;
                    TenSinhVien = _selectedStu.TenSinhVien;
                    HoDem = _selectedStu.HoDem;
                    Lop = _selectedStu.TenLop;

                }
}
        }
        private string _selectedKey;

        public string SelectedKey
        {
            get => _selectedKey;
            set
            {
                if (value != null)
                {
                    _selectedKey = value;
                    OnPropertyChanged("SelectedKey");
                }
            }
        }
        private string _selectedKeyStu;
        public string SelectedKeyStu
        {
            get => _selectedKeyStu;
            set
            {
                if (value != null)
                {
                    _selectedKeyStu = value;
                    OnPropertyChanged("SelectedKeyStu");
                }
            }
        }
        private string _keySub;
        public string KeySub
        {
            get => _keySub;
            set
            {
                if (value != null)
                {
                    _keySub = value;
                    OnPropertyChanged("KeySub");

                    if (SelectedKey != null)
                    {
                        if (SelectedKey.Equals("Mã Giảng Viên"))
                            ListTea = new ObservableCollection<GiangVien>(_repondGV.GetMany(t => t.MaGiangVien.Contains(_keySub)));
                        else
                            ListTea = new ObservableCollection<GiangVien>(_repondGV.GetMany(t => t.HoTen.Contains(_keySub)));
                    }
                }
            }
        }
        private string _keySubStu;
        public string KeySubStu
        {
            get => _keySubStu;
            set
            {
                if (value != null)
                {
                    _keySubStu = value;
                    OnPropertyChanged("KeySubStu");

                    if (SelectedKeyStu != null)
                    {
                        if (SelectedKeyStu.Equals("Mã Sinh Viên"))
                            ListStu = new ObservableCollection<SinhVien>(_repondSV.GetMany(t => t.MaSinhVien.Contains(_keySub)));
                        else
                            ListStu = new ObservableCollection<SinhVien>(_repondSV.GetMany(t => t.TenSinhVien.Contains(_keySub)));
                    }
                }
            }
        }

        private ObservableCollection<string> _listKey;
        
        public ObservableCollection<string> ListKey
        {
            get => _listKey;
            set
            {
                if (value != null)
                {
                    _listKey = value;
                    OnPropertyChanged("ListKey");
                }
            }

        }
        private ObservableCollection<string> _listKeyStu;
        public ObservableCollection<string> ListKeyStu
        {
            get => _listKeyStu;
            set
            {
                if (value != null)
                {
                    _listKeyStu = value;
                    OnPropertyChanged("ListKeyStu");
                }
            }

        }
        public ICommand RefreshData { get; set; }

        public ICommand ThemSinhVien { get; set; }
        public ICommand SuaSinhVien { get; set; }
        public ICommand XoaSinhVien { get; set; }


        public ICommand ThemGiangVien { get; set; }
        public ICommand SuaGiangVien { get; set; }
        public ICommand XoaGiangVien { get; set; }

        private void CreateData()
        {
            ListTea = new ObservableCollection<GiangVien>(_repondGV.GetAll());
            ListKey = new ObservableCollection<string>() { "Tên Giảng Viên" };
            ListStu = new ObservableCollection<SinhVien>(_repondSV.GetAll());
            ListKeyStu = new ObservableCollection<string>() { "Mã Sinh Viên","Tên Sinh Viên" };
            RefreshData = new RelayCommand<object>
            (
                  (p) =>
                  {
                      return true;
                  },
                  (p) =>
                  {
                      MaGiangVien = HoTen = Email = HocVi= Passwords = Role = null;
                      MaSinhVien = TenSinhVien = HoDem = Lop = null;
                  }
                );
            ThemSinhVien = new RelayCommand<object>
                (
                  (p) =>
                  {
                      if (string.IsNullOrEmpty(MaSinhVien))
                          return false;
                      if (string.IsNullOrEmpty(TenSinhVien))
                          return false;
                      if (string.IsNullOrEmpty(HoDem))
                          return false;
                      return true;
                  },
                  (p) =>
                  {
                      var data = new SinhVien() { MaSinhVien = MaSinhVien, TenSinhVien = TenSinhVien, HoDem = HoDem ,TenLop = Lop};

                      var result = _repondSV.Insert(data);
                      if (result != null)
                      {
                          MessageBox.Show("OK");
                          ListStu.Add(result);
                      }

                      else
                          MessageBox.Show("Fails");

                  }
                );
            SuaSinhVien = new RelayCommand<object>
                (
                  (p) =>
                  {
                      if (string.IsNullOrEmpty(MaSinhVien))
                          return false;
                      if (string.IsNullOrEmpty(TenSinhVien))
                          return false;
                      if (string.IsNullOrEmpty(HoDem))
                          return false;
                      if (string.IsNullOrEmpty(Lop))
                          return false;
                      return true;
                  },
                  (p) =>
                  {
                      var data = new SinhVien() { MaSinhVien = MaSinhVien, TenSinhVien = TenSinhVien, HoDem = HoDem,TenLop = Lop };

                      if (_repondSV.Update(data))
                      {
                          MessageBox.Show("OK");
                          ListStu.SingleOrDefault(t => t.MaSinhVien.Equals(SelectedStu.MaSinhVien)).TenSinhVien = TenSinhVien;
                          ListStu.SingleOrDefault(t => t.MaSinhVien.Equals(SelectedStu.MaSinhVien)).HoDem = HoDem;
                          ListStu.SingleOrDefault(t => t.MaSinhVien.Equals(SelectedStu.MaSinhVien)).TenLop = Lop;
                      }
                      else
                          MessageBox.Show("Fails");

                  }
                );
            XoaSinhVien = new RelayCommand<object>
                (
                  (p) =>
                  {
                      if (string.IsNullOrEmpty(MaSinhVien))
                          return false;
                      return true;
                  },
                  (p) =>
                  {
                      if (_repondSV.Delete(MaSinhVien))
                      {
                          MessageBox.Show("OK");
                          ListStu.Remove(ListStu.SingleOrDefault(t => t.MaSinhVien.Equals(SelectedStu.MaSinhVien)));
                      }
                      else
                          MessageBox.Show("Fails");

                  }
                );
            ThemGiangVien = new RelayCommand<object>
               (
                 (p) =>
                 {
                     if (string.IsNullOrEmpty(MaGiangVien))
                         return false;
                     if (string.IsNullOrEmpty(HoTen))
                         return false;
                     if (string.IsNullOrEmpty(Email))
                         return false;
                     if (string.IsNullOrEmpty(HocVi))
                         return false;
                     if (string.IsNullOrEmpty(Passwords))
                         return false;
                     if (string.IsNullOrEmpty(Role))
                         return false;
                     return true;
                 },
                 (p) =>
                 {
                     var data = new GiangVien() { MaGiangVien = MaGiangVien, HoTen = HoTen, Email = Email, HocVi = HocVi ,Passwords = Passwords , Role = Convert.ToInt32(Role)};

                     var result = _repondGV.Insert(data);
                     if (result != null)
                     {
                         MessageBox.Show("OK");
                         ListTea.Add(result);
                     }

                     else
                         MessageBox.Show("Fails");

                 }
               );
            SuaGiangVien = new RelayCommand<object>
                (
                  (p) =>
                  {
                      if (string.IsNullOrEmpty(MaGiangVien))
                          return false;
                      if (string.IsNullOrEmpty(HoTen))
                          return false;
                      if (string.IsNullOrEmpty(Email))
                          return false;
                      if (string.IsNullOrEmpty(HocVi))
                          return false;
                      if (string.IsNullOrEmpty(Passwords))
                          return false;
                      if (string.IsNullOrEmpty(Role))
                          return false;
                      return true;
                  },
                  (p) =>
                  {
                      var data = new GiangVien() { MaGiangVien = MaGiangVien, HoTen = HoTen, Email = Email, HocVi = HocVi, Passwords = Passwords, Role = Convert.ToInt32(Role) };

                      if (_repondGV.Update(data))
                      {
                          MessageBox.Show("OK");
                          ListTea.SingleOrDefault(t => t.MaGiangVien.Equals(SelectedTea.MaGiangVien)).HoTen = HoTen;
                          ListTea.SingleOrDefault(t => t.MaGiangVien.Equals(SelectedTea.MaGiangVien)).Email = Email;
                          ListTea.SingleOrDefault(t => t.MaGiangVien.Equals(SelectedTea.MaGiangVien)).HocVi = HocVi;
                          ListTea.SingleOrDefault(t => t.MaGiangVien.Equals(SelectedTea.MaGiangVien)).Passwords = Passwords;
                          ListTea.SingleOrDefault(t => t.MaGiangVien.Equals(SelectedTea.MaGiangVien)).Role = Convert.ToInt32(Role);
                      }
                      else
                          MessageBox.Show("Fails");

                  }
                );
            XoaGiangVien = new RelayCommand<object>
                (
                  (p) =>
                  {
                      if (string.IsNullOrEmpty(MaGiangVien))
                          return false;
                      return true;
                  },
                  (p) =>
                  {
                      if (_repondGV.Delete(MaGiangVien))
                      {
                          MessageBox.Show("OK");
                          ListTea.Remove(ListTea.SingleOrDefault(t => t.MaGiangVien.Equals(SelectedTea.MaGiangVien)));
                      }
                      else
                          MessageBox.Show("Fails");

                  }
                );

        }
        public PersonViewModel()
        {
            _repondGV = new BaseRepositories<GiangVien>();
            _repondSV = new BaseRepositories<SinhVien>();
            CreateData();
        }
        
    }
}
