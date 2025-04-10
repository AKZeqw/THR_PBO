using System;

public class Karyawan
{
    private string nama;
    private string id;
    private double gajiPokok;

    public string Nama
    {
        get { return nama; }
        set { nama = value; }
    }

    public string ID
    {
        get { return id; }
        set { id = value; }
    }

    public double GajiPokok
    {
        get { return gajiPokok; }
        set { gajiPokok = value; }
    }

    public virtual double HitungGaji()
    {
        return GajiPokok;
    }
}

public class KaryawanTetap : Karyawan
{
    private const double BonusTetap = 500000;
    public override double HitungGaji()
    {
        return GajiPokok + BonusTetap;
    }
}

public class KaryawanKontrak : Karyawan
{
    private const double PotonganKontrak = 200000;
    public override double HitungGaji()
    {
        return GajiPokok - PotonganKontrak;
    }
}

public class KaryawanMagang : Karyawan
{
    public override double HitungGaji()
    {
        return GajiPokok;
    }
}

class Program
{
    static void Main(string[] args)
    {


        Console.Write("Masukkan Jenis Karyawan (Tetap/Kontrak/Magang): ");
        string jenisKaryawan = Console.ReadLine().ToLower();

        if (jenisKaryawan != "tetap" && jenisKaryawan != "kontrak" && jenisKaryawan != "magang")
        {
            Console.WriteLine("Inputan salah.Jenis Karyawan hanya ada Tetap,Kontrak,dan Magang");
            return;
        }

        Console.Write("Masukkan Nama Karyawan: ");
        string nama = Console.ReadLine();

        Console.Write("Masukkan ID Karyawan: ");
        string id = Console.ReadLine();

        Console.Write("Masukkan Gaji Pokok Karyawan: ");
        double gajiPokok = Convert.ToDouble(Console.ReadLine());

        Karyawan karyawan;

        if (jenisKaryawan=="tetap")
        {
            karyawan = new KaryawanTetap();
        }
        else if (jenisKaryawan=="kontrak")
        {
            karyawan = new KaryawanKontrak();
        }
        else
        {
            karyawan = new KaryawanMagang();
        }

        karyawan.Nama = nama;
        karyawan.ID = id;
        karyawan.GajiPokok = gajiPokok;

        Console.WriteLine($"\nKaryawan   : {karyawan.Nama}");
        Console.WriteLine($"ID         : {karyawan.ID}");
        Console.WriteLine($"Gaji Akhir : {karyawan.HitungGaji():C}");
    }
}
