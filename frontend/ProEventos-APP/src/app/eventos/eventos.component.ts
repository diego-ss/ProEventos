import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  eventos: any = [];

  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
    //this.getEventos();
  }

  private getEventos(): void{
    this.httpClient.get("https://localhost:5001/api/eventos").subscribe(
      response => this.eventos = response,
      error => console.error(error)
    );
  }

}
