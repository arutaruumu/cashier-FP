using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using KasirMinimarket.Model.Entity;
using KasirMinimarket.Model.Repository;
using KasirMinimarket.Model.Context;

namespace KasirMinimarket.Controller
{
    public class CustomerCtrlr
    {
        private CustomerRepo _custrepo;

        public int Create(Customer cust)
        {
            int result = 0;

            if (string.IsNullOrEmpty(cust.id_cust))
            {
                MessageBox.Show("id_cust harus diisi", "Peringata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (string.IsNullOrEmpty(cust.nama_cust))
            {
                MessageBox.Show("nama_cust harus diisi", "Peringata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (string.IsNullOrEmpty(cust.alamat))
            {
                MessageBox.Show("alamat harus diisi", "Peringata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (string.IsNullOrEmpty(cust.email))
            {
                MessageBox.Show("email harus diisi", "Peringata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                _custrepo = new CustomerRepo(context);
                result = _custrepo.Create(cust);
            }

            if (result > 0)
            {
                MessageBox.Show("Data pelanggan berhasil disimpan !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data pelanggan gagal disimpan !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }


        //UPDATE
        public int Update(Customer cust)
        {
            int result = 0;

            if (string.IsNullOrEmpty(cust.id_cust) || string.IsNullOrEmpty(cust.nama_cust) || string.IsNullOrEmpty(cust.alamat) || string.IsNullOrEmpty(cust.email) || string.IsNullOrEmpty(cust.no_hp))
            {
                MessageBox.Show("Semua kolom harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                _custrepo = new CustomerRepo(context);
                result = _custrepo.Update(cust);
            }

            if (result > 0)
            {
                MessageBox.Show("Data pelanggan berhasil diperbarui !", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data pelanggan gagal diperbarui !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }
        //DELETE
        public int Delete(Customer cust)
        {
            int result = 0;

            if (string.IsNullOrEmpty(cust.nama_cust))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                _custrepo = new CustomerRepo(context);
                result = _custrepo.Delete(cust);
            }

            if (result > 0)
            {
                MessageBox.Show("Data pelanggan berhasil dihapus !", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data pelanggan gagal dihapus !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }
        public List<Customer> ReadBynama_cust(string nama_cust)
        {
            List<Customer> list = new List<Customer>();
            using (DbContext context = new DbContext())
            {
                _custrepo = new CustomerRepo(context);
                list = _custrepo.ReadBynama_cust(nama_cust);
            }

            return list;
        }

        public List<Customer> ReadAll()
        {
            List< Customer> list = new List<Customer>();
            using (DbContext context = new DbContext())
            {
                _custrepo = new CustomerRepo(context);
                list = _custrepo.ReadAll();
            }

            return list;
        }
    }
}
