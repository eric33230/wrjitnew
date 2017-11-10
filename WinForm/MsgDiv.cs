using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// ��Ϣ���ص�����ί��
/// </summary>
public delegate void DGMsgDiv();//װ����������~~~��
    /// <summary>
    /// ��Ϣ���� ��Timer��ʱ
    /// </summary>
public class MsgDiv : System.Windows.Forms.Label
{
    private Timer timerLable = new Timer();
    /// <summary>
    /// ��Ϣ�ص� ί�ж���
    /// </summary>
    private DGMsgDiv dgCallBack = null;
  

    #region ��ʱ��
    /// <summary>
    /// ��ʱ��
    /// </summary>
    public Timer TimerMsg
    {
        get { return timerLable; }
        set { timerLable = value; }
    } 
    #endregion

    #region  MsgDiv���캯��
    /// <summary>
    /// MsgDiv���캯��
    /// </summary>
    public MsgDiv()
    {
        InitallMsgDiv(7, 7);
    }

    /// <summary>
    /// MsgDiv���캯��
    /// </summary>
    /// <param name="x">��λx������</param>
    /// <param name="y">��λy������</param>
    public MsgDiv(int x, int y)
    {
        InitallMsgDiv(x, y);
    }
    #endregion

    #region  ��ʼ����Ϣ��
    /// <summary>
    /// ��ʼ����Ϣ��
    /// </summary>
    private void InitallMsgDiv(int x, int y)
    {
        this.AutoSize = true;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
        this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        //this.ContextMenuStrip = this.cmsList;
        this.Font = new System.Drawing.Font("����", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        this.ForeColor = System.Drawing.Color.Red;
        this.Location = new System.Drawing.Point(x, y);
        this.MaximumSize = new System.Drawing.Size(980, 525);
        this.Name = "msgDIV";
        this.Padding = new System.Windows.Forms.Padding(7);
        this.Size = new System.Drawing.Size(71, 31);
        this.TabIndex = 1;
        this.Text = "��Ϣ��";
        this.Visible = false;
        //��ί������¼�
        this.DoubleClick += new System.EventHandler(this.msgDIV_DoubleClick);
        this.MouseLeave += new System.EventHandler(this.msgDIV_MouseLeave);
        this.MouseHover += new System.EventHandler(this.msgDIV_MouseHover);
        this.timerLable.Interval = 1000;
        this.timerLable.Tick += new System.EventHandler(this.timerLable_Tick);
    }
    #endregion

    #region ����Ϣ����ӵ�ָ��������
    /// <summary>
    /// ����Ϣ����ӵ�ָ��������Form
    /// </summary>
    /// <param name="form"></param>
    public void AddToControl(Form form)
    {
        form.Controls.Add(this);
    }
    /// <summary>
    /// ����Ϣ����ӵ�ָ��������GroupBox
    /// </summary>
    /// <param name="form"></param>
    public void AddToControl(GroupBox groupBox)
    {
        groupBox.Controls.Add(this);
    }
    /// <summary>
    /// ����Ϣ����ӵ�ָ��������Panel
    /// </summary>
    /// <param name="form"></param>
    public void AddToControl(Panel panel)
    {
        panel.Controls.Add(this);
    }
    #endregion

    //---------------------------------------------------------------------------
    #region ��Ϣ��ʾ ����ز����� hiddenClick��countNumber��constCountNumber
    /// <summary>
    /// ��ǰ��ʾ�˶�õ�������
    /// </summary>
    int hiddenClick = 0;
    /// <summary>
    /// Ҫ��ʾ��õ������� �ɱ����
    /// </summary>
    int countNumber = 3;
    /// <summary>
    /// Ҫ��ʾ��õ������� �̶�����
    /// </summary>
    int constCountNumber = 3; 
    #endregion

    #region ��ʱ�� ��ʾcountNumber���Ӻ��Զ�����div -timerLable_Tick(object sender, EventArgs e)
    private void timerLable_Tick(object sender, EventArgs e)
    {
        if (hiddenClick > countNumber - 2)
        {
            MsgDivHidden();
        }
        else
        {
            hiddenClick++;
            //RemainCount();
        }
    } 
    #endregion

    #region ������Ϣ�� ��ֹͣ��ʱ +void MsgDivHidden()
    /// <summary>
    /// ������Ϣ�� ��ֹͣ��ʱ
    /// </summary>
    public void MsgDivHidden()
    {
        this.Text = "";
        this.Visible = false;
        this.hiddenClick = 0;
        //this.tslblRemainSecond.Text = "";
        if (this.timerLable.Enabled == true)
            this.timerLable.Stop();

        //���� ί�� Ȼ�����ί��
        if (dgCallBack != null && dgCallBack.GetInvocationList().Length > 0)
        {
            dgCallBack();
            dgCallBack -= dgCallBack;
        }
    } 
    #endregion

    #region ����Ϣ������ʾ��Ϣ�ַ��� +void MsgDivShow(string msg)
    /// <summary>
    /// ����Ϣ������ʾ��Ϣ�ַ���
    /// </summary>
    /// <param name="msg">Ҫ��ʾ���ַ���</param>
    public void MsgDivShow(string msg)
    {
        this.Text = msg;
        this.Visible = true;
        this.countNumber = constCountNumber;//Ĭ��������ʾ����Ϊ10;
        this.hiddenClick = 0;//���õ�������
        this.timerLable.Start();
    } 
    #endregion

    #region ����Ϣ������ʾ��Ϣ�ַ��� ������Ϣ��ʧʱ ���ûص����� +void MsgDivShow(string msg, DGMsgDiv callback)
    /// <summary>
    /// ����Ϣ������ʾ��Ϣ�ַ��� ������Ϣ��ʧʱ ���ûص�����
    /// </summary>
    /// <param name="msg">Ҫ��ʾ���ַ���</param>
    /// <param name="callback">�ص�����</param>
    public void MsgDivShow(string msg, DGMsgDiv callback)
    {
        MsgDivShow(msg);
        dgCallBack = callback;
    }
    #endregion

    #region ����Ϣ������ʾ��Ϣ�ַ��� ����ָ��ʱ����Ϣ��ʧʱ ���ûص����� +void MsgDivShow(string msg, int seconds, DGMsgDiv callback)
    /// <summary>
    /// ����Ϣ������ʾ��Ϣ�ַ��� ������Ϣ��ʧʱ ���ûص�����
    /// </summary>
    /// <param name="msg">Ҫ��ʾ���ַ���</param>
    /// <param name="seconds">��Ϣ��ʾʱ��</param>
    /// <param name="callback">�ص�����</param>
    public void MsgDivShow(string msg, int seconds, DGMsgDiv callback)
    {
        MsgDivShow(msg, seconds);
        dgCallBack = callback;
    }  
    #endregion

    #region ����Ϣ������ʾ��Ϣ�ַ�������ָ����Ϣ����ʾ���� +void MsgDivShow(string msg, int seconds)
    /// <summary>
    /// ����Ϣ������ʾ��Ϣ�ַ�������ָ����Ϣ����ʾ����
    /// </summary>
    /// <param name="msg">Ҫ��ʾ���ַ���</param>
    /// <param name="seconds">��Ϣ����ʾ����</param>
    public void MsgDivShow(string msg, int seconds)
    {
        this.Text = msg;
        this.Visible = true;
        this.countNumber = seconds;
        this.hiddenClick = 0;//���õ�������
        this.timerLable.Start();
    } 
    #endregion

    //---------------------------------------------------------------------------
    #region �¼��ǡ������� msgDIV_MouseHover��msgDIV_MouseLeave��msgDIV_DoubleClick
    //�����ͣ����div��ʱ ֹͣ��ʱ
    private void msgDIV_MouseHover(object sender, EventArgs e)
    {
        if (this.timerLable.Enabled == true)
            this.timerLable.Stop();
    }
    //������div���ƿ�ʱ ������ʱ
    private void msgDIV_MouseLeave(object sender, EventArgs e)
    {
        //����Ϣ��������ʾ���ظ���û��ʾ����ʱ����ֹͣ��ʱ������������ʱ��
        if (this.Visible == true && this.timerLable.Enabled == false)
            this.timerLable.Start();
    }
    //˫����Ϣ��ʱ�ر���Ϣ��
    private void msgDIV_DoubleClick(object sender, EventArgs e)
    {
        MsgDivHidden();
    } 
    #endregion

}

