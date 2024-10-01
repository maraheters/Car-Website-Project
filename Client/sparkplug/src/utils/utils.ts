function formatPrice(price: number): string {
    return `$${price.toLocaleString()}`;
}

 function formatMileage(mileage: number): string {
    return `${mileage.toLocaleString()}`;
}

export { formatPrice, formatMileage };