const API_URL = "http://localhost:5140/api"

const fetchWeather = async () => {
    const response = await fetch(`${API_URL}/cars`);
    return response.json();
}

export {fetchWeather};