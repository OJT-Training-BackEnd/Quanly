import './App.scss';
import Login from '../src/pages/login/Login'
import CongTruDiem from './component/cong tru diem/CongTruDiem';
import KhachHang from './component/khach hang/KhachHang';
import CSTD from './component/chinh sach tich diem/CSTD';
import ChinhSuaCSTD from './component/chinh sach tich diem/ChinhSuaCSTD';
import TheThanhVien from './component/the thanh vien/TheThanhVien';
import { Routes, Route } from 'react-router-dom';
import ThemMoiCSTD from './component/chinh sach tich diem/ThemMoiCSTD';
import MenuProjectManage from './component/menu/Menu';
import ThemMoiKhachHang from './component/khach hang/ThemMoiKhachHang';
import ChinhSuaKhachHang from './component/khach hang/ChinhSuaKhachHang';

 
function App() {
  return (
    <>
      <Routes>
        <Route path='/' element={[<MenuProjectManage />,<CongTruDiem />]} />
        <Route path='/khachhang' element={[<MenuProjectManage />,<KhachHang />]}/>
        <Route path='/thethanhvien' element={[<MenuProjectManage />,<TheThanhVien />]}/>
        <Route path='/chinhsachtichdiem' element={[<MenuProjectManage />,<CSTD />]}/>
        <Route path='/themmoichinhsachtichdiem' element={<ThemMoiCSTD />}/>
        <Route path='/login' element={<Login />}/>
        <Route path='/themmoikhachhang' element={<ThemMoiKhachHang />}/>
        <Route path='/chinhsuakhachhang' element={<ChinhSuaKhachHang />}/>
        <Route path='/chinhsuachinhsachtichdiem' element={<ChinhSuaCSTD />}/>
      </Routes>
    </>
  );
}

export default App;
