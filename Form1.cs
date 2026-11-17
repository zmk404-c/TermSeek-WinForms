using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace TermSeek2._0 // 注意：如果你的命名空间不同，请把这里改成你原来的
{
    public partial class Form1 : Form
    {
        // 1. 数据库（完美保留你提供的数据）
        static string[,] ku =
        {
            // 问题数据库
            {
                "404是谁？",
                "ns是什么？",
                "你是什么？",
                "TermSeek怎么使用？",
                "TermSeek支持哪些平台？",
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
                "C#是什么？",
                "WinForms是什么？",
                "如何学习C#？",
                "404错误是什么意思？",
                "Git是什么？",
                "bug是什么意思？",
                "怎么给TermSeek添加更多数据？",
                "你好",
                "帮助",
                "67是什么梗？"
            },
            // 答案数据库
            {
                "404是一个开发者，喜欢开发有趣的工具和项目。",
                "ns是404开发的一个语言。",
                "我是TermSeek，一个基于 C# WinForms 开发的本地桌面搜索工具。",
                "在输入框输入关键词，点击“获取搜索结果”，然后点击下方的结果即可查看详细答案。",
                "目前仅支持 Windows 桌面端（WinForms）。",
                "本项目无需安装，直接在 Visual Studio 中运行源码即可。",
                "已经开源，欢迎访问：https://github.com/zmk404-c/TermSeek.git",
                "目前主要包含 TermSeek 的帮助文档、开发者信息以及一些编程基础知识。",
                "TermSeek 强调本地化、快速检索和可定制工作流；普通搜索引擎更偏向海量网页信息检索。",
                "如果搜索本地数据通常不需要联网，完全离线运行。",
                "可以在 GitHub 的 Issues 页面提交反馈，或联系开发者 3839316842。",
                "可以在代码顶部的 ku 数组中添加你的自定义问答，或者在后续版本中支持配置文件。",
                "目前内置了基础的模糊搜索功能，请等待开发者更新更多命令。",
                "去 GitHub 仓库拉取最新的源码即可更新。",
                "API 正在开发中，敬请期待。",
                "在输入框输入 <cmd> 即可开启开发者模式。",
                "C# 是微软开发的一门面向对象的现代化编程语言，广泛用于开发 Windows 应用、游戏（如 Unity）和 Web 服务。",
                "WinForms（Windows Forms）是 .NET 框架下用于构建 Windows 桌面应用程序的图形用户界面（GUI）库，非常适合初学者。",
                "可以通过微软官方文档、B站教程（如刘铁猛）或动手写一个类似 TermSeek 的小项目来学习。",
                "HTTP 404 表示“未找到”（Not Found），即服务器找不到请求的网页。这也是本开发者名字的由来。",
                "Git 是一个分布式版本控制系统，用于追踪代码修改历史，GitHub 就是基于 Git 的代码托管平台。",
                "Bug 是指计算机程序中的错误或缺陷，导致程序无法按预期运行。",
                "打开源码，找到 static string[,] ku 数组，在问题库和答案库末尾各加一行即可，注意逗号要对应。",
                "你好！欢迎使用 TermSeek 搜索引擎，请输入你想查询的关键词。",
                "你可以尝试搜索：'404'、'C#'、'怎么使用' 或 '更新'。",
                "67 是一个网络流行语，也是测试文件生成器最爱的数字。"
            }
        };

        // 2. 全局控件声明（放在这里，所有方法都能用）
        Panel kuang;
        TextBox huida;
        TextBox shuru;
        Button huoqy;
        int y = 0;

        // 构造函数
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        // 3. 窗体加载事件（负责画界面）
        private void Form1_Load(object sender, EventArgs e)
        {
            // 设置主窗口属性
            this.Text = "TermSeek---搜索引擎";
            this.Size = new Size(400, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // 标签
            Label text = new Label() { Text = "欢迎使用TermSeek搜索引擎", Location = new Point(10, 10), AutoSize = true };
            Label text2 = new Label() { Text = "在下面输入搜索关键词↓", Location = new Point(10, 30), AutoSize = true };
            Label text3 = new Label() { Text = "下面是搜索结果", Location = new Point(10, 110), AutoSize = true };
            this.Controls.Add(text);
            this.Controls.Add(text2);
            this.Controls.Add(text3);

            // 输入框
            shuru = new TextBox();
            shuru.Location = new Point(10, 50);
            shuru.Size = new Size(250, 25);
            shuru.Font = new Font("微软雅黑", 10);
            this.Controls.Add(shuru);

            // 按钮
            huoqy = new Button();
            huoqy.Text = "获取搜索结果";
            huoqy.Location = new Point(270, 49);
            huoqy.Size = new Size(100, 28);
            huoqy.Click += huoqv_shijian;
            this.Controls.Add(huoqy);

            // 灰色边框容器
            kuang = new Panel();
            kuang.Location = new Point(10, 140);
            kuang.Size = new Size(360, 310);
            kuang.BackColor = Color.Gray;
            kuang.Padding = new Padding(2);
            kuang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(kuang);

            // 内部只读多行文本框
            huida = new TextBox();
            huida.Multiline = true;
            huida.ReadOnly = true;
            huida.ScrollBars = ScrollBars.Vertical;
            huida.BorderStyle = BorderStyle.None;
            huida.Dock = DockStyle.Fill;
            huida.Font = new Font("微软雅黑", 10);
            huida.WordWrap = false; // 核心修复：关闭自动换行，防止点击错位
            huida.MouseClick += huida_MouseClick; // 绑定鼠标点击
            kuang.Controls.Add(huida);
        }

        // 4. 搜索按钮逻辑
        private void huoqv_shijian(object sender, EventArgs e)
        {
            huida.Clear();
            string keyword = shuru.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("请输入搜索关键词！", "提示");
                return;
            }

            int total = ku.GetLength(1);
            bool hasResult = false;

            for (int i = 0; i < total; i++)
            {
                // 模糊搜索（忽略大小写）
                if (ku[0, i].IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    hasResult = true;
                    // 👇 核心修改：直接使用 i + 1 作为编号，确保和数据库里的真实序号绝对一致
                    huida.AppendText($"[{i + 1}] {ku[0, i]}\r\n");
                }
            }

            if (!hasResult)
            {
                huida.Text = "抱歉，没有找到与【" + keyword + "】相关的结果。";
            }
            else
            {
                huida.AppendText("\r\n请点击上方结果查看详细答案。");
            }

            huida.SelectionStart = huida.Text.Length;
            huida.ScrollToCaret();
        }

        // 5. 点击弹窗逻辑
        private void huida_MouseClick(object sender, MouseEventArgs e)
        {
            int charIndex = huida.GetCharIndexFromPosition(e.Location);
            int lineIndex = huida.GetLineFromCharIndex(charIndex);

            if (lineIndex >= 0 && lineIndex < huida.Lines.Length)
            {
                string clickedLine = huida.Lines[lineIndex];

                // 确保点击的是带有 "[数字]" 的搜索结果行
                if (!string.IsNullOrWhiteSpace(clickedLine) && clickedLine.StartsWith("["))
                {
                    int endBracketIndex = clickedLine.IndexOf("]");
                    if (endBracketIndex > 0)
                    {
                        string numStr = clickedLine.Substring(1, endBracketIndex - 1);

                        if (int.TryParse(numStr, out int resultId))
                        {
                            int actualIndex = resultId - 1;

                            if (actualIndex >= 0 && actualIndex < ku.GetLength(1))
                            {
                                string question = ku[0, actualIndex];
                                string answer = ku[1, actualIndex];

                                MessageBox.Show($"问题：{question}\n\n答案：{answer}", "TermSeek 搜索结果");
                            }
                        }
                    }
                }
            }
        }
    }
}