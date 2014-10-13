Insert into NhaCungCap(TenNcc,DiaChi,Phone,NgayXoa)
values (N'Nhà cung cấp 1',N'Mai Dịch, Cầu Giấy, Hà Nội','041523611','1-12-2014')
Insert into NhaCungCap(TenNcc,DiaChi,Phone,NgayXoa)
values (N'Nhà cung cấp 2',N'Mai Dịch, Cầu Giấy, Hà Nội','041523611','1-12-2014')
Insert into NhaCungCap(TenNcc,DiaChi,Phone,NgayXoa)
values (N'Nhà cung cấp 3',N'Mai Dịch, Cầu Giấy, Hà Nội','041523611','1-12-2014')
-------------------------------------------------------
Insert into DanhMuc (TenDanhMuc,NhaCungCapID,NgayXoa)
values (N'Tủ rượu đẹp','1','1-12-2014')
Insert into DanhMuc (TenDanhMuc,NhaCungCapID,NgayXoa)
values (N'Quầy bar','2','1-12-2014')
Insert into DanhMuc (TenDanhMuc,NhaCungCapID,NgayXoa)
values (N'Trống','3','1-12-2014')
-------------------------------------------------------
Insert into LoaiSanPham(TenLoaiSp,DanhMucID,NgayXoa)
values (N'Tủ rượu','1','1-12-2014')
Insert into LoaiSanPham(TenLoaiSp,DanhMucID,NgayXoa)
values (N'Quầy bar','2','1-12-2014')
Insert into LoaiSanPham(TenLoaiSp,DanhMucID,NgayXoa)
values (N'Trống rượu','3','1-12-2014')
-------------------------------------------------------
Insert into SanPham(SanPhamID,TenSp,LoaiSpID,Model,Gia,AnhDaiDien,SoLuong,MieuTaNgan,MieuTaChiTiet,TrangThai,NgayXoa)
values (N'TR001',N'Tủ rượu 1','1','T001','1200000',N'tu-ruou-dep-01-128x128.jpg','10',N'Mẫu tủ đẹp trang nhã, hợp lý cho phòng khách và văn phòng',N'Mẫu tủ đẹp trang nhã, hợp lý cho phòng khách và văn phòng',N'Còn hàng','1-12-2014')
Insert into SanPham(SanPhamID,TenSp,LoaiSpID,Model,Gia,AnhDaiDien,SoLuong,MieuTaNgan,MieuTaChiTiet,TrangThai,NgayXoa)
values (N'TR002',N'Tủ rượu 2','1','T002','1500000',N'tu-ruou-dep-02-128x128.jpg','2',N'Mẫu tủ đẹp trang nhã, hợp lý cho phòng khách và văn phòng',N'Mẫu tủ đẹp trang nhã, hợp lý cho phòng khách và văn phòng',N'Còn hàng','1-12-2014')
Insert into SanPham(SanPhamID,TenSp,LoaiSpID,Model,Gia,AnhDaiDien,SoLuong,MieuTaNgan,MieuTaChiTiet,TrangThai,NgayXoa)
values (N'TR003',N'Tủ rượu 3','1','T003','2000000',N'tu-ruou-dep-03-128x128.jpg','2','Mẫu tủ đẹp trang nhã, hợp lý cho phòng khách và văn phòng','Mẫu tủ đẹp trang nhã, hợp lý cho phòng khách và văn phòng',N'Còn hàng','1-12-2014')
Insert into SanPham(SanPhamID,TenSp,LoaiSpID,Model,Gia,AnhDaiDien,SoLuong,MieuTaNgan,MieuTaChiTiet,TrangThai,NgayXoa)
values (N'TR004',N'Tủ rượu 4','1','T003','1000000',N'tu-ruou-dep-04-128x128.jpg','2','Mẫu tủ đẹp trang nhã, hợp lý cho phòng khách và văn phòng','Mẫu tủ đẹp trang nhã, hợp lý cho phòng khách và văn phòng',N'Còn hàng','1-12-2014')
Insert into SanPham(SanPhamID,TenSp,LoaiSpID,Model,Gia,AnhDaiDien,SoLuong,MieuTaNgan,MieuTaChiTiet,TrangThai,NgayXoa)
values (N'TR005',N'Tủ rượu 5','1','T003','3000000',N'tu-ruou-dep-05-128x128.jpg','2','Mẫu tủ đẹp trang nhã, hợp lý cho phòng khách và văn phòng','Mẫu tủ đẹp trang nhã, hợp lý cho phòng khách và văn phòng',N'Còn hàng','1-12-2014')
Insert into SanPham(SanPhamID,TenSp,LoaiSpID,Model,Gia,AnhDaiDien,SoLuong,MieuTaNgan,MieuTaChiTiet,TrangThai,NgayXoa)
values (N'BR001',N'Quầy bar tủ bếp 1','2','B001','5000000',N'quay bar tu bep 01-150x150.jpg','2',N'Mẫu quầy bar tủ bếp đẹp hiện đại, hợp lý cho bếp của bạn',N'Mẫu quầy bar tủ bếp đẹp hiện đại, hợp lý cho bếp của bạn',N'Còn hàng','1-12-2014')
Insert into SanPham(SanPhamID,TenSp,LoaiSpID,Model,Gia,AnhDaiDien,SoLuong,MieuTaNgan,MieuTaChiTiet,TrangThai,NgayXoa)
values (N'BR002',N'Quầy bar tủ bếp 2','2','B002','4000000',N'quay bar tu bep 02-150x150.jpg','1',N'Mẫu quầy bar tủ bếp đẹp hiện đại, hợp lý cho bếp của bạn',N'Mẫu quầy bar tủ bếp đẹp hiện đại, hợp lý cho bếp của bạn',N'Còn hàng','1-12-2014')
Insert into SanPham(SanPhamID,TenSp,LoaiSpID,Model,Gia,AnhDaiDien,SoLuong,MieuTaNgan,MieuTaChiTiet,TrangThai,NgayXoa)
values (N'BR003',N'Quầy bar tủ bếp 3','2','B003','4000000',N'quay bar tu bep 03-150x150.jpg','1',N'Mẫu quầy bar tủ bếp đẹp hiện đại, hợp lý cho bếp của bạn',N'Mẫu quầy bar tủ bếp đẹp hiện đại, hợp lý cho bếp của bạn',N'Còn hàng','1-12-2014')

-----------------------------------------------------
Insert into DanhMucAnh(SanPhamID,TenAnh,NgayXoa)
values ('TR001',N'tu-ruou-dep-01-128x128.jpg','1-12-2014')
Insert into DanhMucAnh(SanPhamID,TenAnh,NgayXoa)
values ('TR001',N'tu-ruou-dep-01-150x150.jpg','1-12-2014')

Insert into DanhMucAnh(SanPhamID,TenAnh,NgayXoa)
values ('TR002',N'tu-ruou-dep-02-128x128.jpg','1-12-2014')
Insert into DanhMucAnh(SanPhamID,TenAnh,NgayXoa)
values ('TR002',N'tu-ruou-dep-02-150x150.jpg','1-12-2014')

Insert into DanhMucAnh(SanPhamID,TenAnh,NgayXoa)
values ('TR003',N'tu-ruou-dep-03-128x128.jpg','1-12-2014')
Insert into DanhMucAnh(SanPhamID,TenAnh,NgayXoa)
values ('TR003',N'tu-ruou-dep-03-150x150.jpg','1-12-2014')

Insert into DanhMucAnh(SanPhamID,TenAnh,NgayXoa)
values ('TR004',N'tu-ruou-dep-04-128x128.jpg','1-12-2014')
Insert into DanhMucAnh(SanPhamID,TenAnh,NgayXoa)
values ('TR004',N'tu-ruou-dep-04-150x150.jpg','1-12-2014')

Insert into DanhMucAnh(SanPhamID,TenAnh,NgayXoa)
values ('TR005',N'tu-ruou-dep-05-128x128.jpg','1-12-2014')
Insert into DanhMucAnh(SanPhamID,TenAnh,NgayXoa)
values ('TR005',N'tu-ruou-dep-05-150x150.jpg','1-12-2014')

Insert into DanhMucAnh(SanPhamID,TenAnh,NgayXoa)
values ('BR001',N'quay bar tu bep 01-150x150.jpg','1-12-2014')
Insert into DanhMucAnh(SanPhamID,TenAnh,NgayXoa)
values ('BR001',N'quay bar tu bep 02-150x150.jpg','1-12-2014')
Insert into DanhMucAnh(SanPhamID,TenAnh,NgayXoa)
values ('BR001',N'quay bar tu bep 03-150x150.jpg','1-12-2014')

Insert into DanhMucAnh(SanPhamID,TenAnh,NgayXoa)
values ('BR002',N'quay bar tu bep 02-150x150.jpg','1-12-2014')
Insert into DanhMucAnh(SanPhamID,TenAnh,NgayXoa)
values ('BR002',N'quay bar tu bep 03-150x150.jpg','1-12-2014')

