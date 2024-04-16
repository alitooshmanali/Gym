﻿namespace Gym.Application.Aggregates.Audits;

public class Audit
{
    public Guid Id { get; set; }

    public Guid AggregateId { get; set; }

    public Guid UserId { get; set; }

    public string Action { get; set; }

    public string Data { get; set; }

    public string Client { get; set; }

    public string ClientAddress { get; set; }

    public DateTimeOffset Time { get; set; }
}