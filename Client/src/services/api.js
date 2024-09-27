const API_URL = "http://localhost:5140"

const fetchWeather = async () => {
    const response = await fetch(`${API_URL}/weatherforecast`);
    return response.json();
}

export {fetchWeather};