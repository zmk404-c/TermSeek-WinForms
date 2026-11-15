using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TermSeek2._0
{
    public partial class Form1 : Form
    {
        //数据库声明
        static string[,] ku =
                  {
                       // 问题数据库
                      {
                          "404是谁？", "ns是什么？", "你是什么？",
                          "TermSeek怎么使用？", "TermSeek支持哪些平台？",
                          "TermSeek如何安装？",
                          "TermSeek是开源的吗？",
                          "TermSeek支持搜索哪些内容？",
                          "TermSeek和普通搜索有什么区别？",
                          "TermSeek需要联网吗？",
                          "如何反馈问题或建议？",
                          "如何自定义TermSeek的配置？",
                          "TermSeek支持哪些命令？",
                          "如何更新TermSeek？",
                          "TermSeek有没有API？",
                          "怎么开启开发者模式？",
                      },
                      // 答案数据库
                      {
                          "404是一个开发者，喜欢开发有趣的工具和项目。",
                          "ns是404开发的一个语言。",
                          "我是TermSeek，一个命令行搜索工具。",
                          "TermSeek通常通过在命令行输入关键词，然后输入答案编号来查看结果。",
                          "只支持命令行环境。",
                          "https://github.com/zmk404-c/TermSeek.git",
                          "已经开源，https://github.com/zmk404-c/TermSeek.git",
                          "具体范围取决于配置和插件。",
                          "TermSeek强调命令行内快速检索和可定制工作流，普通搜索引擎更偏向网页信息检索。",
                          "如果搜索本地数据通常不需要联网。",
                          "注意3839316842。",
                          "学习C#编程。",
                          "请等待开发者模式。",
                          "github上我会更新。",
                          "等待更新",
                          "输入<cmd>",
                      }
                  };
        //栈声明
        static int[] zhan= new int[100];
        //统一的公平标签声明
        Label huidatext = new Label();
        int y;
        TextBox shuru;
        Panel kuang = new Panel();
        TextBox huida;
        //int sv = ku.GetLength(1);

        // 前端 前后端分离 养成良好的编程习惯
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load!);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //第3次补丁 优化了用户体验
            // 1. 设置窗口打开时的初始大小 (宽, 高)
            this.Size = new Size(400, 500);

            // 2. 设置窗口能被缩到的最小尺寸（防止用户把窗口拉得太小，控件全挤没了）
            this.MinimumSize = new Size(350, 450);

            // 3. 让窗口一启动就在屏幕正中间（体验非常好）
            this.StartPosition = FormStartPosition.CenterScreen;
            // 创建n个控件并设置其属性
            Label text;
            Label text2;
            //TextBox shuru;
            Button huoqv;
            //TextBox huida;
            Label text3;

            //创建一个边框容器
            //Panel kuang = new Panel();
            kuang.Location = new Point(10, 140);
            kuang.Size = new Size(250, 250);
            kuang.BackColor = Color.Gray;
            kuang.Padding = new Padding(2);
            // 更改窗口标题栏的文字
            this.Text = "TermSeek---搜索引擎";
            //介绍输出格式
            //定义输出框属性（因为比较复杂 所以单独布置）
            huida = new TextBox();
            //核心
            huida.Multiline = true;
            huida.ReadOnly = true;
            huida.ScrollBars = ScrollBars.Vertical;
            //补丁：改变了初框架边框的不明显的问题
            huida.BorderStyle = BorderStyle.None;
            huida.Dock = DockStyle.Fill;
            //外观设置
            //huida.Location = new Point(10, 140);
            //huida.Size = new Size(250,250);
            huida.Font = new Font("微软雅黑", 10);

            //核心补丁
            kuang.Controls.Add(huida);
            //核心补丁
            kuang.Controls.Add(huida);

            //  新增这一行：给文本框绑定鼠标点击事件
            huida.MouseClick += huida_MouseClick;

            // 创建n个控件并设置其属性
            text = new Label();
            text2 = new Label();
            shuru = new TextBox();
            huoqv = new Button();
            text3 = new Label();


            text.Text = "欢迎使用TermSeek搜索引擎";
            text2.Text = "在下面输入搜索关键词↓";
            huoqv.Text = "获取搜索结果";
            text3.Text = "下面是搜索结果";

            text.Location = new Point(10, 10);
            text2.Location = new Point(10, 30);
            shuru.Location = new Point(10, 50);
            huoqv.Location = new Point(10, 80);
            text3.Location = new Point(10, 110);

            text.AutoSize = true;
            text2.AutoSize = true;
            text3.AutoSize = true;

            //统一的输出 养成良好的编程习惯
            this.Controls.Add(text);
            this.Controls.Add(text2);
            this.Controls.Add(text3);
            //输出以及配套的边框
            //this.Controls.Add(huida);
            this.Controls.Add(kuang);
            // 补齐属性并将输入控件添加到窗体中
            shuru.Size = new Size(200, 20);
            shuru.Font = new Font("微软雅黑", 10);
            this.Controls.Add(shuru);
            // 补齐属性并将按钮控件添加到窗体中
            huoqv.Size = new Size(100, 30);
            huoqv.Click += huoqv_shijian!;
            this.Controls.Add(huoqv);
        }
        //后端以及具体逻辑
        //按钮和检索逻辑
        private void huoqv_shijian(object sender, EventArgs e)
        {
            
            int sv = ku.GetLength(1);
            //初始化条件
            huida.Clear();
            y = 0;
            int k = 0;
            string dian = shuru.Text.Trim();
            //最初检测
            if (string.IsNullOrEmpty(dian))
            {
                MessageBox.Show("请输入搜索内容！", "提示");
                return;
            }
            //开始配对数据库
            for (int i = 0; i < sv; i++)
            {
                if (ku[0, i].Contains(dian))
                {
                    y = y + 1;
                    huida.Text += $"第" + y + "个回答:";
                    huida.Text += ku[0, i];
                    huida.AppendText("\r\n");
                    zhan[y - 1] = i;
                    //huida.Text += 
                    //补丁：自动滚到最底下 优化用户体验
                    huida.SelectionStart = huida.Text.Length;
                    huida.ScrollToCaret();
                    //huida.Clear();
                    k = 1;
                }
            }
            if (k == 0)
            {
                huida.Text += "没有匹配到结果";
            }
        }
        //鼠标点击事件
        private void huida_MouseClick(object sender, MouseEventArgs e)
        {
            // 1. 获取鼠标点击位置的字符索引
            int charIndex = huida.GetCharIndexFromPosition(e.Location);

            // 2. 根据字符索引，算出点击的是哪一行（行号从0开始）
            int lineIndex = huida.GetLineFromCharIndex(charIndex);


            string[] lines = huida.Lines;

            // 4. 防呆设计：确保点击的行是有效且不为空的
            if (lineIndex >= 0 && lineIndex < lines.Length)
            {
                string shu = lines[lineIndex];

                if (!string.IsNullOrWhiteSpace(shu))
                {
                    // 5. 弹出弹窗，显示点击的那行内容
                    MessageBox.Show($"{ku[1, zhan[lineIndex]]}", "结果详情 ");
                }
            }

        }
    }
}
