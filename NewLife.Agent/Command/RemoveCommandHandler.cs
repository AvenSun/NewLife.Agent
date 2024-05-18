﻿namespace NewLife.Agent.Command;

/// <summary>
/// 卸载服务命令处理类
/// </summary>
public class RemoveCommandHandler : BaseCommandHandler
{
    /// <summary>
    /// 卸载服务构造函数
    /// </summary>
    /// <param name="service"></param>
    public RemoveCommandHandler(ServiceBase service) : base(service)
    {
    }

    /// <inheritdoc/>
    public override String Cmd { get; set; } = CommandConst.Remove;

    /// <inheritdoc />
    public override String Description { get; set; } = "卸载服务";

    /// <inheritdoc />
    public override Char? ShortcutKey { get; set; } = '2';

    /// <inheritdoc />
    public override Boolean IsShowMenu()
    {
        return Service.Host.IsInstalled(Service.ServiceName);
    }

    /// <inheritdoc/>
    public override void Process(String[] args)
    {
        Service.Host.Remove(Service.ServiceName);
        // 稍微等一下，以便后续状态刷新
        Thread.Sleep(500);
    }
}