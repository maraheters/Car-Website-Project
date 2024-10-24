
const local = true;
const API_URL = local ? "http://localhost:5140/api" : "http://172.20.36.81:5140/api"

export type Article = {
    source: {
      id: string | null;
      name: string;
    };
    author: string;
    title: string;
    description: string;
    url: string;
    urlToImage: string;
    publishedAt: string;
    content: string;
}

const fetchNews = async (page: number, pageSize: number): Promise<Article[]> => {
    const response = await fetch(`${API_URL}/News/${page}, ${pageSize}`);
    if (!response.ok) {
        throw new Error(`HTTP error: ${response.statusText}`);
    }
    const data = await response.json();
    return data.articles as Article[];
}

export { fetchNews }