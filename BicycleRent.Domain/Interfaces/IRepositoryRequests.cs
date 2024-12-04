﻿using BicycleRent.Domain.Entities;
using BicycleRent.Domain.JobRequestsTypes;

namespace BicycleRent.Domain.Interfaces;

/// <summary>
/// Репозиторий для реализаций запросов в коллекциях
/// </summary>
public interface IRepositoryRequests
{
    /// <summary>
    /// 1) Вывести информацию обо всех спортивных велосипедах
    /// </summary>
    public List<Bicycle> GetInfoSportBike();


    /// <summary>
    /// 2) Вывести информацию обо всех клиентах, которые брали в аренду горные велосипеды, 
    /// упорядочить по ФИО.
    /// </summary>
    public List<BicycleRenter> GetInfoClientMountain();


    /// <summary>
    /// 3) Вывести суммарное время аренды велосипедов каждого типа.
    /// </summary>
    public List<NumberAndEntity<double, BicycleType>> GetSumTimeRentForType();

    /// <summary>
    /// 4) Вывести информацию о клиентах, бравших велосипеды на прокат больше всего раз.
    /// </summary>
    public List<NumberAndEntity<int, BicycleRenter>> GetClientsMaxRent();


    /// <summary>
    /// 5) Вывести информацию о топ 5 наиболее часто арендуемых велосипедов.
    /// </summary>
    public List<NumberAndEntity<int, Bicycle>> GetTopRentBikes();


    /// <summary>
    /// 6) Вывести информацию о минимальном, максимальном и 
    /// среднем времени аренды велосипедов.
    /// </summary>
    public List<double> GetStatisticTimeRent();
}
