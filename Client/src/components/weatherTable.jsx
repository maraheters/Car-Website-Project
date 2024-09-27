import { useEffect, useState } from "react";
import {fetchWeather} from "../services/api.js"

export default function WeatherTable() {
	const [weatherData, setWeatherData] = useState([]);
	const [error, setError] = useState(null);

	useEffect(() => {
		const fetchWeatherData = async () => {
			try {
				const response = await fetchWeather();
				setWeatherData(response);
			} catch(err) {
				setError(err.message)
			}
		}

		fetchWeatherData();

	}, []) 

	if (error) return <p>{error}</p>

	return (
		<div>
		  <h1>Weather Data</h1>
		  <table>
			<thead>
			  <tr>
				<th>Date</th>
				<th>Temperature (°C)</th>
				<th>Temperature (°F)</th>
				<th>Summary</th>
			  </tr>
			</thead>
			<tbody>
			  {weatherData.map((item) => (
				<tr key={item.date}>
				  <td>{item.date}</td>
				  <td>{item.temperatureC}</td>
				  <td>{item.temperatureF}</td>
				  <td>{item.summary}</td>
				</tr>
			  ))}
			</tbody>
		  </table>
		</div>
	  );
}