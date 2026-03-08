# The IT book online shop

API สำหรับร้านหนังสือ IT ออนไลน์ (เข้าสู่ระบบ, ดูรายการหนังสือ, กดถูกใจหนังสือ)

---

## หมายเหตุ: API รายการหนังสือ (GET /api/books)

เนื่องจาก **https://api.itbook.store/1.0/search/mysql** ไม่สามารถใช้งานได้ จึงจำ (mock) การตอบกลับของ API รายการหนังสือให้มีรูปแบบเดียวกับที่กำหนดไว้ โดยอ้างอิงจาก `apiitbookstore.json`

เมื่อ API ภายนอกใช้งานได้แล้ว สามารถเปลี่ยนกลับไปเรียก `https://api.itbook.store/1.0/search/mysql` ได้

---

## วิธี Compile และ Run Application

### ข้อกำหนด (Prerequisites)

- **.NET SDK 10.0**
- **PostgreSQL**

### 1. Clone / เปิดโปรเจกต์

```bash
cd TestBookApi
```

### 2. ตั้งค่า Connection String

แก้ไข `appsettings.json` หรือ `appsettings.Development.json` ให้ตรงกับ PostgreSQL ของคุณ:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=bookapi;Username=postgres;Password=YOUR_PASSWORD"
}
```

และสร้างฐานข้อมูล `bookapi` รวมถึงตาราง `users`, `user_likes` ตามสคริปต์ใน `Cretetable.sql`

### 3. Restore packages

```bash
dotnet restore
```

### 4. Build (Compile)

```bash
dotnet build
```

### 5. Run

```bash
dotnet run
```

เมื่อรันสำเร็จ แอปจะฟังที่ `http://localhost:8xxx` และสามารถเปิด **Swagger UI** ได้ที่:

- `https://localhost:8xxx/swagger`

For test Home Pro
