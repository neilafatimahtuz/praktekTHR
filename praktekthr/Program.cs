using System;

// Kelas Induk (Parent Class) untuk semua jenis employee
class Employee
{
    private string name;        
    // Nama karyawan, disimpan secara rahasia (private)
    private string id;          
    // ID karyawan, juga disimpan private
    private double gajiPokok;   
    // Gaji pokok karyawan

    // Constructor adalah fungsi khusus saat object dibuat
    public Employee(string name, string id, double gajiPokok)
    {
        this.name = name;            
        // Menyimpan nama yang dimasukkan ke variabel name
        this.id = id;                
        // Menyimpan ID ke variabel id
        this.gajiPokok = gajiPokok;  
        // Menyimpan gaji pokok
    }

    // Fungsi untuk ambil nama karyawan
    public string GetName() => name;  
    // Mengembalikan nama
    public void SetName(string name) => this.name = name;  
    // Mengganti nama

    // Fungsi untuk ambil ID
    public string GetID() => id;  
    // Mengembalikan ID
    public void SetID(string id) => this.id = id;  
    // Mengganti ID

    // Fungsi untuk ambil gaji pokok
    public double GetGajiPokok() => gajiPokok;  
    // Mengembalikan gaji pokok
    public void SetGajiPokok(double gajiPokok) => this.gajiPokok = gajiPokok; 
    // Mengganti gaji pokok

    // Fungsi virtual agar bisa diganti oleh anak-anaknya
    public virtual double HitungGaji()
    {
        return gajiPokok;  
        // Default-nya hanya gaji pokok
    }

    // Menampilkan info dasar karyawan
    public virtual void TampilkanInfo()
    {
        Console.WriteLine($"Name: {name}"); 
        // Tampilkan nama
        Console.WriteLine($"ID: {id}");  
        // Tampilkan ID
        Console.WriteLine($"Gaji Pokok: {gajiPokok}");  
        // Tampilkan gaji pokok
    }
}

// Kelas anak untuk employee tetap
class EmployeeTetap : Employee
{
    public EmployeeTetap(string name, string id, double gajiPokok) : base(name, id, gajiPokok) { }  
    // Panggil constructor parent

    public override double HitungGaji()
    {
        return GetGajiPokok() + 500000;  
        // Tambah bonus 500 ribu
    }
}

// Kelas anak untuk employee kontrak
class EmployeeKontrak : Employee
{
    public EmployeeKontrak(string name, string id, double gajiPokok) : base(name, id, gajiPokok) { }  
    // Panggil constructor parent

    public override double HitungGaji()
    {
        return GetGajiPokok() - 200000;  
        // Kurangi potongan 200 ribu
    }
}

// Kelas anak untuk employee magang
class EmployeeMagang : Employee
{
    public EmployeeMagang(string name, string id, double gajiPokok) : base(name, id, gajiPokok) { }  
    // Panggil constructor parent

    public override double HitungGaji()
    {
        return GetGajiPokok();  
        // Gaji tetap, tidak ada bonus atau potongan
    }
}

// Program utama tempat semua berjalan
class Program
{
    static void Main()
    {
        Console.WriteLine("Silahkan pilih jenis employee (1. Tetap, 2. Kontrak, 3. Magang):");  
        // Minta user pilih jenis karyawan
        int pilihan = int.Parse(Console.ReadLine());  
        // Baca pilihan user dan ubah jadi angka

        Console.Write("Masukkan Name: ");  
        // Minta user masukkan nama
        string name = Console.ReadLine();  
        // Simpan nama

        Console.Write("Masukkan ID: ");  
        // Minta user masukkan ID
        string id = Console.ReadLine();  
        // Simpan ID

        Console.Write("Masukkan Gaji Pokok: ");  
        // Minta user masukkan gaji pokok
        double gajiPokok = double.Parse(Console.ReadLine());  
        // Simpan gaji pokok

        Employee employee = null;  
        // Buat variabel untuk menyimpan objek karyawan

        // Pilih objek berdasarkan jenis karyawan
        switch (pilihan)
        {
            case 1:
                employee = new EmployeeTetap(name, id, gajiPokok);  
                // Buat karyawan tetap
                break;
            case 2:
                employee = new EmployeeKontrak(name, id, gajiPokok);  
                // Buat karyawan kontrak
                break;
            case 3:
                employee = new EmployeeMagang(name, id, gajiPokok);  
                // Buat karyawan magang
                break;
            default:
                Console.WriteLine("Pilihan tidak dapat dideteksi / tidak valid.");  
                // Kalau pilihannya salah
                return;  
                // Keluar dari program
        }

        employee.TampilkanInfo();  
        // Tampilkan info karyawan
        Console.WriteLine($"Gaji Akhir Employee: {employee.HitungGaji()}");  
        // Hitung dan tampilkan gaji akhir
    }
}
