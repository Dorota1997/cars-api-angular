export interface IOrder {
    id: number;
    components: string;
    orderDate: string;
    dealer: string;
}

export interface IOrders {
    data: Array<IOrder>;
    pageNumber: number;
    pageSize: number;
    nextPage: string;
    previousPage: string;
}