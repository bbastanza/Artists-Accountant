import React from "react";
import { Artwork, TableProps } from "./../helpers/interfaces";
import { formatMoney, formatTime } from "./../helpers/beautifyNumber";
import "./css/Table.css";

const Table: React.FC<TableProps> = ({ userData }: TableProps) => {
    const calculateHourly = (artworks: Artwork[]): number => {
        let totalSales = 0;
        let totalHours = 0;
        artworks.forEach(artwork => {
            totalSales += artwork.margin;
            totalHours += artwork.timeSpentMinutes / 60;
        });
        const hourlyRate = totalSales / totalHours;
        return hourlyRate;
    };

    const calculateTotalTime = (artworks: Artwork[]): string => {
        let totalMinutes = 0;
        artworks.forEach(artwork => (totalMinutes += artwork.timeSpentMinutes));
        return formatTime(totalMinutes);
    };

    return (
        <div className="row table-container shadow-lg">
            <table className="col-sm-4 col-xs-12 table">
                <thead>
                    <tr>
                        <th>Collected Margin</th>
                        <th>Margin Potential</th>
                        <th>Uncollected Income</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>{formatMoney(userData?.totalMarginCollected)}</td>
                        <td>{formatMoney(userData?.totalMarginPotential)}</td>
                        <td>{formatMoney(userData?.totalUncollectedIncome)}</td>
                    </tr>
                </tbody>
            </table>
            <table className="col-sm-4 col-xs-12  table">
                <thead>
                    <tr>
                        <th>Collected Income</th>
                        <th>Total Expences</th>
                        <th>Total Pieces</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>{formatMoney(userData?.totalCollectedIncome)}</td>
                        <td>{formatMoney(userData?.totalExpenses)}</td>
                        <td>{userData?.artWorks.length}</td>
                    </tr>
                </tbody>
            </table>
            <table className="col-sm-3 col-xs-12 table">
                <thead>
                    <tr>
                        <th>Avg. Hourly</th>
                        <th>Time Working</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>{formatMoney(calculateHourly(userData?.artWorks))}</td>
                        <td>{calculateTotalTime(userData?.artWorks)}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    );
};

export default Table;
