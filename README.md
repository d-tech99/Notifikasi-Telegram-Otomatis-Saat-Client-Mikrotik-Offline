# 🔔 Notifikasi Telegram Otomatis Saat Client Mikrotik Offline
### VB.NET + Tik4Net Tutorial by D-Tech Project

Proyek ini adalah kelanjutan dari seri **Monitoring PPPoE Client Mikrotik** menggunakan VB.NET dan **Tik4Net**.  
Tujuan utama aplikasi ini adalah memberikan **notifikasi otomatis melalui Telegram** ketika salah satu klien PPPoE terputus (offline) tanpa perlu membuka Winbox.

---

## ⚙️ Fitur Utama
- 🔄 Monitoring otomatis setiap 5 detik terhadap daftar klien aktif di Mikrotik  
- 📡 Deteksi perubahan status (online/offline)  
- 💬 Pengiriman pesan otomatis ke Telegram melalui Bot API  
- 🪟 Tampilan DataGridView real-time di VB.NET  
- 🧩 Kode sumber lengkap dan mudah dipahami untuk pengembangan lebih lanjut  

---

## 🧠 Cara Kerja Aplikasi
1. Aplikasi membaca daftar klien aktif dari router Mikrotik setiap 5 detik.
2. Sistem menyimpan daftar klien sebelumnya untuk dibandingkan dengan daftar baru.
3. Jika ada klien yang hilang, sistem menganggapnya **offline**.
4. Fungsi `SendTelegramMessage()` memanggil **Telegram Bot API** untuk mengirim pesan alert.
