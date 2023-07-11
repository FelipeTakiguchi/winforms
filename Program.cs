using System;
using System.Drawing;
using System.Windows.Forms;

ApplicationConfiguration.Initialize();

var form = new Form
{
    WindowState = FormWindowState.Maximized,
    FormBorderStyle = FormBorderStyle.None,
    BackColor = Color.LimeGreen,
    TransparencyKey = Color.LimeGreen,
};

var width = 470;
var height = 600;

Panel panel = new()
{
    Width = width,
    Height = height,
    BackColor = Color.Pink,
    Location = new Point(10, 10),
};

PictureBox pictureBox = new()
{
    ImageLocation = "trevis.png",
    Location = new Point(10, 10),
    Dock = DockStyle.Fill,
    SizeMode = PictureBoxSizeMode.StretchImage,
};

panel.Controls.Add(pictureBox);
form.Controls.Add(panel);

// var show = false;

var timer = new Timer
{
    Interval = 1
};

var speedX = 5;
var speedY = 5;
var rand = Random.Shared;

timer.Tick += delegate
{
    var x = panel.Location.X;
    var y = panel.Location.Y;
    
    if(x >= (form.Width - width) || x <= 0)
    {
        speedX *= -1;
        panel.BackColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
    }
    else if(y >= (form.Height - height) || y <= 0)
    {
        speedY *= -1;
        panel.BackColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
    }

    x += speedX;
    y += speedY;

    panel.Location = new Point(x, y);
    
    // if(show)
    // {
    //     form.Hide();
    //     show = false;
    // }

    // var rand = Random.Shared;

    // if (rand.Next(100) < 20)
    // {
    //     form.Show();
    //     show = true;
    // }
};

form.Load += delegate
{
    // form.Hide();
    timer.Start();
};

form.KeyPreview = true;
form.KeyDown += (s, e) =>
{
    if (e.KeyCode == Keys.Escape)
        Application.Exit();
};

// var bt = new Button
// {
//     Width = 400,
//     Height = 120,
//     Text = "Olá, Windows Forms!",
//     Anchor = AnchorStyles.Left | AnchorStyles.Right,
// };

// form.Controls.Add(bt);

// EventHandler func = (o, e) =>
// {
//     var bt = o as Button;
//     bt.Text = "Oi";
// };

// bt.Click += func;

Application.Run(form);
