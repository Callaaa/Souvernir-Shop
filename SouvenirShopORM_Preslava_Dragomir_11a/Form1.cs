using ORMSouvenirShop.Controller;
using ORMSouvenirShop.Model;
using SouvenirShopORM_Preslava_Dragomir_11a;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SouvenirShopORM_Preslava_Dragomir_11a
{
    public partial class Form1 : Form
    {
        SouvenirLogic souvenirLogic = new SouvenirLogic();
        SouvenirTypeLogic souvenirTypeLogic = new SouvenirTypeLogic();
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadRecord(Souvenir souvenir)
        {
            txtProductNumber.Text = souvenir.Id.ToString();
            txtName.Text = souvenir.Name;
            txtPrice.Text = souvenir.Price.ToString();
            rtDescription.Text = souvenir.Description.ToString();
            comboBoxType.Text = souvenir.SouvenirTypes.Name;
        }
        private void SelectAll()
        {
            List<Souvenir> allSouvenirs = souvenirLogic.GetAll();
            listBoxSouvenirs.Items.Clear();
            foreach (var item in allSouvenirs)
            {
                listBoxSouvenirs.Items.Add($"{item.Id}, {item.Name}");
            }
        }
        private void ClearScreen()
        {
            txtProductNumber.Clear();
            txtName.Clear();
            txtPrice.Clear();
            rtDescription.Clear();
            comboBoxType.Text = "";
            pictureBox1.Image = Image.FromFile("gift.png");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<SouvenirType> allSouvenirTypes = souvenirTypeLogic.GetAllTypes();
            comboBoxType.DataSource = allSouvenirTypes;
            comboBoxType.DisplayMember = "Name";
            comboBoxType.ValueMember = "Id";
            comboBoxType.SelectedIndex = -1;
            SelectAll();
            pictureBox1.BorderStyle = BorderStyle.None;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Souvenir newSouvenir = new Souvenir();
                newSouvenir.Name = txtName.Text;
                newSouvenir.Description = rtDescription.Text;
                newSouvenir.Price = double.Parse(txtPrice.Text);
                newSouvenir.SouvenirTypeId = (int)comboBoxType.SelectedValue;
                souvenirLogic.Create(newSouvenir);
                MessageBox.Show("Записът е успешно добавен!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearScreen();
                SelectAll();
            }
            catch (Exception)
            {
                DialogResult answer = MessageBox.Show("Грешка!\nОпитай пак!", "Внимание!", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);
                if (answer == DialogResult.Cancel)
                {
                    ClearScreen();
                }
            }
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int findId = 0;
                findId = int.Parse(txtProductNumber.Text);
                Souvenir findedSouvenir = souvenirLogic.Get(findId);

                if (findedSouvenir == null)
                {
                    DialogResult answer = MessageBox.Show("Такъв запис не съществува!\n Въведете Id за търсене!",
                        "Внимание!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    if (answer == DialogResult.Cancel)
                    {
                        ClearScreen();
                    }
                    txtProductNumber.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    if (findedSouvenir == null)
                    {
                        DialogResult answer = MessageBox.Show("Такъв запис не съществува!\n Въведете Id за търсене!",
                        "Внимание!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                        if (answer == DialogResult.Cancel)
                        {
                            ClearScreen();
                        }
                        txtProductNumber.Focus();
                        return;
                    }
                    LoadRecord(findedSouvenir);
                }
                else
                {
                    DialogResult answer2 = MessageBox.Show("Предстои обновяване на запис!\nПродължавате ли?",
                      "Важно!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (answer2 == DialogResult.Yes)
                    {
                        Souvenir updatedSouvenir = new Souvenir();
                        updatedSouvenir.Name = txtName.Text;
                        updatedSouvenir.Description = rtDescription.Text;
                        updatedSouvenir.Price = double.Parse(txtPrice.Text);
                        updatedSouvenir.SouvenirTypeId = (int)comboBoxType.SelectedValue;
                        souvenirLogic.Update(findId, updatedSouvenir);
                        ClearScreen();                       
                    }
                    SelectAll();
                }
            }
            catch (Exception)
            {
                DialogResult answer = MessageBox.Show("Грешка!\nОпитай пак!", "Внимание!", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);
                if (answer == DialogResult.Cancel)
                {
                    ClearScreen();
                }
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int findId = 0;
                findId = int.Parse(txtProductNumber.Text);
                Souvenir findedSouvenir = souvenirLogic.Get(findId);
                if (findedSouvenir == null)
                {
                    DialogResult answer = MessageBox.Show("Такъв запис не съществува!\n Въведете Id за търсене!",
                        "Внимание!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    if (answer == DialogResult.Cancel)
                    {
                        ClearScreen();
                    }
                    txtProductNumber.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    if (findedSouvenir == null)
                    {
                        DialogResult answer = MessageBox.Show("Такъв запис не съществува!\n Въведете Id за търсене!",
                        "Внимание!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                        if (answer == DialogResult.Cancel)
                        {
                            ClearScreen();
                        }
                        txtProductNumber.Focus();
                        return;
                    }
                    LoadRecord(findedSouvenir);
                }
                else
                {
                    DialogResult answer1 = MessageBox.Show("Наистина ли искате да изтриете запис No " + findId + "?",
                    "Внимание!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                    if (answer1 == DialogResult.Yes)
                    {
                        souvenirLogic.Delete(findId);
                        ClearScreen();
                    }
                    SelectAll();
                }
            }
            catch (Exception)
            {
                DialogResult answer = MessageBox.Show("Грешка!\nОпитай пак!", "Внимание!", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);
                if (answer == DialogResult.Cancel)
                {
                    ClearScreen();
                }
            }
        }
        private void buttonFind_Click(object sender, EventArgs e)
        {
            try
            {
                int findId = 0;
                findId = int.Parse(txtProductNumber.Text);
                Souvenir findedSouvenir = souvenirLogic.Get(findId);

                if (findedSouvenir == null)
                {
                    DialogResult answer = MessageBox.Show("Такъв запис не съществува!\n Въведете Id за търсене!",
                        "Внимание!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    if (answer == DialogResult.Cancel)
                    {
                        ClearScreen();
                    }
                    txtProductNumber.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    if (findedSouvenir == null)
                    {
                        DialogResult answer = MessageBox.Show("Такъв запис не съществува!\n Въведете Id за търсене!",
                        "Внимание!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                        if (answer == DialogResult.Cancel)
                        {
                            ClearScreen();
                        }
                        txtProductNumber.Focus();
                        return;
                    }
                    LoadRecord(findedSouvenir);
                }
                else
                {
                    LoadRecord(findedSouvenir);
                    SelectAll();
                }
            }
            catch (Exception)
            {
                DialogResult answer = MessageBox.Show("Грешка!\nОпитай пак!", "Внимание!", MessageBoxButtons.OKCancel,
                 MessageBoxIcon.Warning);
                if (answer == DialogResult.Cancel)
                {
                    ClearScreen();
                }
            }
        }
        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.Text == "За морето")
            {
                pictureBox1.Image = Image.FromFile("vodaCvete.png");
            }
            else if (comboBoxType.Text == "За дома")
            {
                pictureBox1.Image = Image.FromFile("Vazi.png");
            }
            else if (comboBoxType.Text == "За нея")
            {
                pictureBox1.Image = Image.FromFile("zaNeq.png");
            }
            else if (comboBoxType.Text == "За него")
            {
                pictureBox1.Image = Image.FromFile("vinoMan.png");
            }
            else
            {
                pictureBox1.Image = Image.FromFile("gift.png");
            }
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearScreen();
        }
    }
}

