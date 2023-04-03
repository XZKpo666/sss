using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 期中作業
{
    public partial class Form1 : Form
    {
        int health = 100;
        int atk = 20;
        int potion = 1;

        int enyhealth = 100;
        int enyatk = 20;

        bool isAtk = false;

        Queue bt = new Queue();
        int btNum = 0;
        string[] chat = new string[100];

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            enyhealth -= atk;
            label5.Text = enyhealth.ToString();
            BattleTable(3);
            BattleTable(1);
            isAtk = true;
            enemy();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            enyatk = 0;
            BattleTable(4);
            BattleTable(1);
            enemy();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (health < 85)health += 15;
            else if(health < 100 && health >= 85) health = 100;
            label3.Text = health.ToString();
            BattleTable(5);
            BattleTable(1);
            enemy();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (potion == 1)
            {
                if (health < 70) health += 30;
                else if (health < 100 && health >= 70) health = 100;
                label3.Text = health.ToString();
                BattleTable(8);
                potion -= 1;
                label4.Text = potion.ToString() + "x";
            }
        }

        void enemy()
        {
            Random skill = new Random();
            int i = skill.Next(0, 5);
            if (i >= 3)
            {
                health -= enyatk;
                label3.Text = health.ToString();
                BattleTable(6);
            }
            else
            {
                if(isAtk == true) 
                {
                    enyhealth += 20;                   
                }
                BattleTable(7);
            }
            BattleTable(2);
            enyatk = 20;
            isAtk = false;
        }

        void BattleTable(int x)
        {
            if (btNum == 26)
            {
                bt.Dequeue();
                bt.Enqueue(Chat(x));
                textBox1.Text = string.Join("\r\n", bt.ToArray());
            }
            else
            {
                btNum++;
                bt.Enqueue(Chat(x));
                textBox1.Text = string.Join("\r\n", bt.ToArray());
            }
        }

        string Chat(int x)
        {
            chat[0] = "戰鬥開始";
            chat[1] = "輪到了對手的回合";
            chat[2] = "輪到了我的回合";
            chat[3] = "我對敵人造成了" + atk.ToString() + "點傷害";
            chat[4] = "我使用防禦抵擋下一個攻擊";
            chat[5] = "我恢復了15滴血";
            chat[6] = "敵人對我造成了" + enyatk.ToString() + "點傷害";
            chat[7] = "敵人使用了防禦抵擋我的攻擊";
            chat[8] = "我使用了藥水恢復了30滴血";

            return chat[x];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = "我";
            label2.Text = "敵人";
            label3.Text = health.ToString();
            label5.Text = enyhealth.ToString();
            label4.Text = potion.ToString() + "x";
            BattleTable(0);
            button1.Text = "攻擊20";
            button2.Text = "防禦";
            button3.Text = "回血15";
            button4.Text = "藥水";

            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label5.Visible = true;
            label4.Visible = true;
            textBox1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = false;
        }

    }
}
