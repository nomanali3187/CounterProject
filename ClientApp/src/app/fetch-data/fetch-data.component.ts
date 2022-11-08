import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {
  inventory: item[];
  timerCount: number;
  interval: any;
  httpClient: HttpClient;
  baseUrl: string;
  httpOptions: HttpHeaders;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.httpClient = http;
    this.baseUrl = baseUrl;
    this.httpOptions = new HttpHeaders();
    this.httpOptions.append('Access-Control-Allow-Origin', '*');
    this.httpOptions.append('Content-Type', 'application/json');
  }

  ngOnInit() {
    this.getTimer();
    this.getInventory();
  }

  getTimer() {
    this.httpClient.get<number>(this.baseUrl + 'InventoryAndTimer/GetTimer').subscribe(result => {
      this.timerCount = result;
      this.startTimer();
    }, error => console.error(error));
  }

  getInventory() {
    this.httpClient.get<item[]>(this.baseUrl + 'InventoryAndTimer/GetInventory').subscribe(result => {
      this.inventory = result;
    }, error => console.error(error));
  }

  getTimerCompletedMessage() {
    var message = 'timer is zero'
    this.httpClient.post(this.baseUrl + 'TimerCompleted/TimerCompletedMessage', message).subscribe(result => {
      
    }, error => console.error(error));
  }


  startTimer() {
    this.interval = setInterval(() => {
      if (this.timerCount > 0) {
        this.timerCount--;
      } else {
        this.pauseTimer();
        this.getTimerCompletedMessage();
      }
    }, 1000)
  }

  pauseTimer() {
    clearInterval(this.interval);
  }

}

interface item {
  description: string;
  count: number;
}
