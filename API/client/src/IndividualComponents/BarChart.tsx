import "./css/BarChart.css";
import React, { useState } from "react";
import { Bar } from "react-chartjs-2";
import { Artwork, ChartProps, ChartDataSets, ChartData, ChartOptions, ChartScales } from "./../helpers/interfaces";

const BarChart: React.FC<ChartProps> = ({ artworks }: ChartProps) => {
    const [sortBy, setSortBy] = useState<string>("margn");
    artworks = artworks.sort((a: Artwork, b: Artwork) => b.salePrice - a.salePrice);

    const allocateColors = (count: number): string[] => {
        const colors: string[] = [];
        for (let i = 0; i < count; i++) {
            colors.push(i % 2 === 1 ? "#9090ff" : "#9381ff");
        }
        return colors;
    };

    const dataSetData: any[] =
        sortBy === "margin"
            ? artworks.map(artwork => (!!artwork.margin ? artwork.margin.toFixed(2) : 0))
            : artworks.map(artwork =>
                  !!artwork.margin && !!artwork.timeSpentMinutes
                      ? (artwork.margin / (artwork.timeSpentMinutes / 60)).toFixed(2)
                      : 0
              );

    const dataSetLabels: string[] = artworks.map(artwork => (!!artwork.pieceName ? artwork.pieceName : "No Name"));

    const dataSets: ChartDataSets[] = [
        {
            label: sortBy === "margin" ? "Margin" : "Hourly Rate",
            data: dataSetData,
            backgroundColor: allocateColors(artworks.length),
        },
    ];

    const scales: ChartScales = {
        // prettier-ignore
        yAxes: [{ticks: {beginAtZero: true}}],
    };

    const chartData: ChartData = {
        labels: dataSetLabels,
        datasets: dataSets,
    };

    const chartOptions: ChartOptions = {
        responsive: true,
        maintainAspectRatio: false,
        scales: scales,
    };

    return (
        <>
            <div className="chart-container">
                <Bar data={chartData} options={chartOptions} />
            </div>
            <p className="tool-tip-p">
                I don't see the piece I am looking for. <span className="tool-tip">Why?</span>
            </p>
            <h3>View</h3>
            <div className="btn-container-chart">
                <button onClick={() => setSortBy("margin")} className="btn btn-purple shadow">
                    Margin
                </button>
                <button onClick={() => setSortBy("hourly")} className="btn btn-purple shadow">
                    Hourly Rate
                </button>
            </div>
        </>
    );
};

export default BarChart;
