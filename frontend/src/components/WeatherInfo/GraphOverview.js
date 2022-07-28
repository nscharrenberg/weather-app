import {useSelector} from "react-redux";
import {Fragment} from "react";
import {CartesianGrid, Line, Tooltip, XAxis, YAxis, LineChart, Legend} from "recharts";

const GraphOverview = () => {
    const overview = useSelector((state) => state.weather.overview);

    if (overview == null || overview.length === 0) {
        return (
            <Fragment></Fragment>
        );
    }

    return (
        <Fragment>
            <LineChart width={1200} height={400} data={overview}>
                <Line type="monotone" dataKey="temperature" stroke="#4ad6ed" activeDot={{ r: 8 }} />
                <Line type="monotone" dataKey="feelTemperature" stroke="#59787D" />
                <Line type="monotone" dataKey="groundTemperature" stroke="#46E3A1" />
                <CartesianGrid stroke="#ccc" strokeDasharray="5 5" />
                <XAxis dataKey="timestamp" />
                <YAxis />
                <Tooltip />
                <Legend/>
            </LineChart>
        </Fragment>
    );

};

export default GraphOverview;