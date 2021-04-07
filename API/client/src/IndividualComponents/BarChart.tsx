import React, { useState } from "react";
import { Bar } from "react-chartjs-2";
import { ChartProps } from "./../helpers/interfaces";
import "./css/BarChart.css";

const BarChart: React.FC<ChartProps> = ({ artworks }: ChartProps) => {
    const [sortBy, setSortBy] = useState<string>("margn");
    artworks = artworks.sort((a, b) => b.salePrice - a.salePrice);

    const allocateColors = (count: number): string[] => {
        const colors: string[] = [];
        for (let i = 0; i < count; i++) {
            colors.push(i % 2 === 1 ? "#9090ff" : "#9381ff");
        }
        return colors;
    };

    const chartData = {
        labels:
            sortBy === "margin"
                ? artworks.map(artwork => (!!artwork.pieceName ? artwork.pieceName : "No Name"))
                : artworks.map(artwork => (!!artwork.pieceName ? artwork.pieceName : "No Name")),
        datasets: [
            {
                label: sortBy === "margin" ? "Margin" : "Hourly Rate",
                data:
                    sortBy === "margin"
                        ? artworks.map(artwork => (!!artwork.margin ? artwork.margin : 0))
                        : artworks.map(artwork =>
                              !!artwork.margin && !!artwork.timeSpentMinutes
                                  ? artwork.margin / (artwork.timeSpentMinutes / 60)
                                  : 0
                          ),
                backgroundColor: allocateColors(artworks.length),
            },
        ],
    };

    return (
        <>
            <div className="chart-container">
                <Bar
                    redraw={true}
                    data={chartData}
                    options={{
                        maintainAspectRatio: false,
                    }}
                />
            </div>
            <p>
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
