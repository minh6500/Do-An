CREATE DATABASE TPCN
GO
USE TPCN
GO
CREATE TABLE CHUYENMUC
(
	MACM INT IDENTITY(1,1) PRIMARY KEY,
	TENCM NVARCHAR(100) NOT NULL,
	URLCM TEXT,
)

INSERT INTO CHUYENMUC(TENCM) VALUES(N'Làm đẹp')
INSERT INTO CHUYENMUC(TENCM) VALUES(N'Mỹ phẩm thiên nhiên')
INSERT INTO CHUYENMUC(TENCM) VALUES(N'Bà bầu')
INSERT INTO CHUYENMUC(TENCM) VALUES(N'Não & tim mạch')
INSERT INTO CHUYENMUC(TENCM) VALUES(N'Hồi phục & bồi bổ')
INSERT INTO CHUYENMUC(TENCM) VALUES(N'Xương khớp')

GO

CREATE TABLE LOAISP
(
	MALOAI INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	TENLOAI NVARCHAR(100) NOT NULL,
	URLLOAISP TEXT,
	MACM INT REFERENCES CHUYENMUC(MACM)
)
INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Chăm sóc da',1)
INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Nở ngực',1)
INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Tóc & móng',1)
INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Chăm sóc toàn diện',1)

INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Dưỡng ngày',2)
INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Dưỡng đêm',2)
INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Dưỡng ẩm',2)
INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Tẩy & rửa',2)
INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Làm trắng & sáng',2)
INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Trị nám',2)
INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Trị mụn & sẹo',2)
INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Chống lão hóa',2)
INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Tế bào gốc',2)
INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Khác',2)

INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Bổ sung toàn diện',3)
INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Trí não thai nhi',3)

INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Não',4)
INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Tim mạch',4)

INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Đông trùng hạ thảo',5)
INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Nhân sâm',5)
INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Linh chi',5)
INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Yến sào',5)

INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Thái hóa khớp',6)
INSERT INTO LOAISP(TENLOAI,MACM) VALUES(N'Bệnh loãng xương',6)

CREATE TABLE SANPHAM
(
	MASP INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	TENSP NVARCHAR(100) NOT NULL,
	MOTA NTEXT NOT NULL,
	HINHANH TEXT,
	NGAYCAPNHAT DATETIME NOT NULL,
	DONGIA INT NOT NULL,
	KHUYENMAI INT,
	THANHTOANTRUCTUYEN NVARCHAR(MAX),
	URL TEXT,
	NOIDUNG NTEXT,
	MALOAI INT FOREIGN KEY (MALOAI) REFERENCES LOAISP(MALOAI) NOT NULL,
)
set dateformat dmy

INSERT INTO SANPHAM(TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI) VALUES(N'Làm trắng da Crystal Tomato',N'Crystal Tomato là sản phẩm đột phá trong công nghệ dưỡng trắng da, bổ sung những tinh chất giúp dưỡng trắng da từ sâu bên trong.','1.png','4/10/2016',5050000,1,1)
INSERT INTO SANPHAM(TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI) VALUES(N'Nở ngực Piacer Pueraria',N'Piacer Pueraria với chiết xuất từ củ pueraria có tác dụng tăng cường sản sinh hormone sinh dục nữ, làm tăng kích thích vòng một nở nang, săn chắc.','2.png','4/10/2016',1900000,2,2)
INSERT INTO SANPHAM(TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI) VALUES(N'Tinh chất giúp mọc tóc và làm tóc chắc khỏe Carita Hair Loss Care Serum',N'Carita Hair Loss Care giúp mọc tóc và làm tóc chắc khỏe, ngăn chặn tóc bị gãy rụng, giúp bạn có một mái tóc dày, mềm mại và bóng mượt.','3.png','4/10/2016',4095000,3,3)
INSERT INTO SANPHAM(TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI) VALUES(N'Nhau thai hươu Purtier Placenta',N'Purtier Placenta được có tác dụng làm đẹp da, hỗ trợ điều trị một số bệnh tật, tăng cường sức đề kháng, duy trì độ khoẻ mạnh cho toàn cơ thể.','4.png','13/9/2016',9000000,4,2)

INSERT INTO SANPHAM(TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI) VALUES(N'Kem dưỡng trắng da ngày Carita Beauty Diamond Anti-Ageing Precious Cream',N'Carita Beauty Diamond Anti-Ageing Precious Cream có tác dụng nuôi dưỡng làn da trắng hồng và làm trẻ hoá làn da khoẻ mạnh, sáng đẹp rạng rỡ như kim cương.','5.png','29/9/2016',25602000,5,2)
INSERT INTO SANPHAM(TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI) VALUES(N'Kem dưỡng trắng da đêm Carita Beauty Diamond Midnight Concentrate Cream',N'Carita Beauty Diamond Midnight Concentrate Cream là loại kem dưỡng da vào ban đêm, hiệu quả tối ưu trong việc nuôi dưỡng và tái tạo lại da tươi tắn, tràn đầy sức sống.','6.png','4/10/2016',17907000,6,3)
INSERT INTO SANPHAM(TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI) VALUES(N'Kem dưỡng ẩm Mesoestetic Hydra Vital Factor K 500ml',N'Mesoestetic Hydra Vital Factor K là giải pháp bổ sung lượng nước cần thiết giúp da được dưỡng ẩm tối đa, tăng cường khả năng phục hồi và tái sinh tế bào da mới.','7.png','30/9/2016',13725000,7,3)
INSERT INTO SANPHAM(TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI) VALUES(N'Bộ dưỡng trắng da Lovite True Blanc',N'Lovite True Blanc tích hợp 4 bước dưỡng da độc đáo theo công thức độc quyền, giúp hoàn thành liệu trình chăm sóc da, mang đến làn da trắng sáng toàn diện.','8.png','3/10/2016',4950000,8,3)
INSERT INTO SANPHAM(TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI) VALUES(N'Kem dưỡng da cao cấp Lancôme Absolue LExtrait',N'Absolue LExtrait chứa đến 2 triệu tế bào hoa hồng tinh khiết chắt lọc từ thiên nhiên, giúp da săn chắc, đàn hồi và rạng ngời hẳn lên sau vài tuần sử dụng.','9.png','4/10/2016',12350000,9,3)
INSERT INTO SANPHAM(TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI) VALUES(N'Bộ trị nám chuyên sâu Mesoestetic Cosmelan Pack',N'Mesoestetic Cosmelan Pack mang đến giáp pháp chuyên nghiệp giúp loại bỏ nám hiệu quả, dưỡng ẩm, làm trắng và phục hồi làn da sáng khoẻ tự nhiên.','10.png','2/10/2016',15953000,10,3)
INSERT INTO SANPHAM(TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI) VALUES(N'Tinh chất xoá nhăn, giảm rạn da, chữa sẹo thâm iS Clinical Super Serum Advance+ 60ml',N'iS Clinical Super Serum Advance+ giúp làm mờ thâm sạm, dưỡng da sáng màu, cải thiện cấu trúc da, tăng sinh collagen, ngăn ngừa sự hình thành sẹo, cho bề mặt da mịn màng, căng mượt.','11.png','4/10/2016',6279000,11,3)
INSERT INTO SANPHAM(TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI) VALUES(N'Kem dưỡng da hoàng cung Whoo Hwanyu Go',N'Whoo Hwanyu Go được tạo nên từ những thành phần Đông y cực kì quý hiếm, đem lại hiệu quả tái sinh làn da, cho da quay lại nét trẻ trung của 10 năm trước.','12.png','4/10/2016',15000000,12,1)
INSERT INTO SANPHAM(TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI) VALUES(N'Kem dưỡng trắng và chống lão hóa Lancôme Absolue Precious Cells White Aura',N'Lancôme Absolue Precious Cells White Aura kích hoạt khả năng tự tái tạo da, chống lão hoá, giảm sự sạm màu da, làm đồng đều màu da, giúp làn da trắng sáng, căng mịn.','13.png','5/10/2016',6650000,13,2)
INSERT INTO SANPHAM(TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI) VALUES(N'Kem làm dịu da tức thời Mesoestetic Fast Skin Repair 500ml',N'Mesoestetic Fast Skin Repair là giải pháp “cấp cứu” làn da hiệu quả, giúp làm giảm các kích ứng và sưng tấy cho da nhạy cảm.','14.png','5/10/2016',9923000,14,1)

INSERT INTO SANPHAM(TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI) VALUES(N'Vitamin tổng hợp cho bà bầu Nature Made Prenatal Multi + DHA',N'Nature Made Prenatal Multi + DHA giúp tăng cường sự phát triển hệ thần kinh của thai nhi và sức khỏe của người mẹ khi đang mang thai.','16.png','5/10/2016',600000,16,3)

INSERT INTO SANPHAM(TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI) VALUES(N'An Cung Ngưu Hoàng Hoàn (Hàn Quốc)',N'An Cung Ngưu Hoàng Hoàn (Hàn Quốc) được bào chế với công thức Đông y đặc biệt, giúp phòng ngừa các bệnh về tim, điều hòa huyết áp, hỗ trợ điều trị bệnh tai biến mạch máu não, ngăn ngừa đột quỵ, đồng thời thanh nhiệt và an thần tốt.','17.jpg','5/10/2016',2850000,17,3)
INSERT INTO SANPHAM(TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI) VALUES(N'Tỏi đen và Hành đen',N'Tỏi đen và Hành đen có công dụng chống lão hoá, làm giảm cholesterol, hạ thấp lượng mỡ và đường trong máu, bảo vệ sức khoẻ tim mạch, tăng sức đề kháng, giải độc cơ thể.','18.png','5/10/2016',1750000,18,3)

INSERT INTO SANPHAM(TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI) VALUES(N'Đông trùng hạ thảo Tây Tạng nguyên con 100g',N'Đông trùng hạ thảo Tây Tạng nguyên con với chất lượng hàng đầu, cung cấp những dưỡng chất tối ưu giúp hồi phục và nâng cao sức khỏe con người.','19.png','5/10/2016',180000000,19,3)
INSERT INTO SANPHAM(TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI) VALUES(N'Cao hắc sâm Geumsan',N'Cao hắc sâm Geumsan có tác dụng bồi bổ sức khỏe vượt trội hơn hẳn các loại nhân sâm thông thường, giúp làm tăng sức đề kháng và chống lão hóa cho cơ thể.','20.png','5/10/2016',7600000,20,3)
INSERT INTO SANPHAM(TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI) VALUES(N'Nấm linh chi thượng hoàng núi Royal Korea Phellinus Linteus Mushroom',N'Royal Korea Phellinus Linteus Mushroom là nấm linh chi thượng hoàng núi rất quý hiếm có nhiều công dụng trong việc bồi bổ sức khỏe và phòng ngừa một số bệnh nan y.','21.png','5/10/2016',15000000,21,3)
INSERT INTO SANPHAM(TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI) VALUES(N'Yến huyết tinh chế Madam Lynn 100g',N'Yến huyết tinh chế Madam Lynn có màu đỏ hoặc nâu đỏ, chứa nhiều thành phần dinh dưỡng quý hiếm, rất tốt để phục hồi và bồi bổ sức khỏe cho cả gia đình.','22.png','5/10/2016',16900000,22,3)

INSERT INTO SANPHAM(TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI) VALUES(N'Bổ khớp N-Acetyl Glucosamine 1000mg 30 viên',N'Giảm 15% từ sản phẩm thứ 2, giá chỉ 1.402.000 đ] 
N-Acetyl Glucosamine 1000mg giúp phát huy khả năng hỗ trợ điều trị đau nhức xương khớp của glucosamine gấp 3 lần, hỗ trợ phòng ngừa, làm chậm quá trình thoái hóa khớp.','23.png','5/10/2016',1485000,23,3)
INSERT INTO SANPHAM(TENSP,MOTA,HINHANH,NGAYCAPNHAT,DONGIA,KHUYENMAI,MALOAI) VALUES(N'Nhung hươu tươi Neza 100g',N'Nhung hươu tươi Neza chứa các tinh chất dinh dưỡng có công dụng bồi bổ sức khỏe, bổ thận tráng dương, tăng cường sinh lực.','24.png','5/10/2016',1358000,24,3)

CREATE TABLE KHACHHANG
(
	MAKH INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	TENKH NVARCHAR(100) NOT NULL,
	SDT CHAR(11) NOT NULL,
	DIACHI NTEXT NOT NULL,
	EMAIL CHAR(100) NOT NULL,
	USERNAME CHAR(20) NOT NULL,
	PASS CHAR(20) NOT NULL,
)


CREATE TABLE DONDATHANG
(
	MAD INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	NGAYDAT DATE NOT NULL,
	TENDAIDIEN NVARCHAR(100) NOT NULL,
	SDT CHAR(11) NOT NULL,
	DIACHIGIAO NTEXT NOT NULL,
	TINHTRANGTHANHTOAN bit,
	TINHTRANGGIAOHANG bit,
	MAKH INT FOREIGN KEY (MAKH) REFERENCES KHACHHANG(MAKH),
)

CREATE TABLE CTDDH
(
	MASP INT,
	MAD INT,
	DONGIA INT,
	SOLUONG INT,
	PRIMARY KEY (MASP,MAD),
	FOREIGN KEY (MASP) REFERENCES SANPHAM(MASP),
	FOREIGN KEY (MAD) REFERENCES DONDATHANG(MAD),
)

CREATE TABLE LIENHE
(
	MALH INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	EMAIL TEXT NOT NULL,
	CHUDE NTEXT NOT NULL,
	NOIDUNG NTEXT NOT NULL,
)

CREATE TABLE ADMINLOGIN
(
	MAAD INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	USERNAME CHAR(20) NOT NULL,
	PASS CHAR(20) NOT NULL,
	TENAD NVARCHAR(50) NOT NULL,
)