import { Injectable } from "@angular/core";
import { WeatherForecast } from "../modelInterfaces/weatherForecast.model";
import * as signalR from '@aspnet/signalr';

@Injectable({
    providedIn: "root"
})
export class SignalRService {

    public data: WeatherForecast[];

    private connection: signalR.HubConnection;

    constructor() { }

    public startConnection = () => {
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl("https://localhost:5001/weatherForecast").build();

        this.connection.start()
            .then(() => console.log("Connection started."))
            .catch((error) => console.log("Hub connection failed with error: " + error))
    }

    public addDataListener = () => {
        this.connection.on("transferWeatherForecast", (data) => {
            this.data = data;
            console.log("received new forecast: " + data);
        })
    }
}