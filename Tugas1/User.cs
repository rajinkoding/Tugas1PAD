using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tugas1
{
    public class User
    {
        //1. username
        //2. Nama Lengkap
        //3. Password
        //4. Confirm Password
        //5. Umur
        //6. Jenis Kelamin
        //7. Status Pendidikan
        //8. Email
        //9. Nomor Handphone
        //10. Alamat

        public string username { get; set; }
        public string nama_lengkap { get; set; }
        public string password { get; set; }
        public string confirm_password { get; set; }
        public int umur { get; set; }
        public string jenis_kelamin { get; set; }
        public string status_pendidikan { get; set; }
        public string email { get; set; }
        public string nomor_handphone { get; set; }
        public string alamat { get; set; }

        public User(string username, string namaLengkap, string password, string confirmPassword, int umur, string jenisKelamin, string statusPendidikan, string email, string nomorHandphone, string alamat)
        {
            this.username = username;
            this.nama_lengkap = namaLengkap;
            this.password = password;
            this.confirm_password = confirmPassword;
            this.umur = umur;
            this.jenis_kelamin = jenisKelamin;
            this.status_pendidikan = statusPendidikan;
            this.email = email;
            this.nomor_handphone = nomorHandphone;
            this.alamat = alamat;
        }
    }
}
