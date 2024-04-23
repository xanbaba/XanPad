using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XanPad
{
    public partial class Form1 : Form
    {
        private const string CursorPositionFormat = "Ln {0} Col {1}";
        private const string CapsLockIndicator = "Caps Lock: {0}";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cursorPositionLabel.Text = string.Format(CursorPositionFormat, 0, 0);
            capsLockIndicatorLabel.Text = string.Format(CapsLockIndicator, IsKeyLocked(Keys.CapsLock));
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            capsLockIndicatorLabel.Text = string.Format(CapsLockIndicator, IsKeyLocked(Keys.CapsLock));
            cursorPositionLabel.Text = string.Format(CursorPositionFormat, richTextBox1.SelectionStart, 0);
        }
    }
}


public static class Utility
{
    ///for System.Windows.Forms.TextBox
    public static System.Drawing.Point GetCaretPoint(System.Windows.Forms.RichTextBox textBox)
    {
        int start = textBox.SelectionStart;
        if (start == textBox.TextLength)
            start--;

        return textBox.GetPositionFromCharIndex(start);
    }
}