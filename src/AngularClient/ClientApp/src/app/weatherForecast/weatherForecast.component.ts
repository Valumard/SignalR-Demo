import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WeatherForecast } from '../modelInterfaces/weatherForecast.model';
import { SignalRService } from '../services/signalR.service';

@Component({
  selector: 'app-weather-forecast',
  templateUrl: './weatherForecast.component.html'
})
export class WeatherForecastComponent implements OnInit {
  public forecasts: WeatherForecast[];

  constructor(private http: HttpClient, public signalRService: SignalRService) { }

  ngOnInit() {
    this.signalRService.startConnection();
    this.signalRService.addDataListener();
    this.startHttpRequest();
  }

  private startHttpRequest = () => {
    this.http.get("https://localhost:5001/api/weatherForecast")
      .subscribe(res => {
        console.log(res);
      })
  }
}

