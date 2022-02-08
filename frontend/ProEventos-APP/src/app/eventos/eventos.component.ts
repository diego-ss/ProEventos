import { EventoService } from './../services/evento.service';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  eventos: any = [];
  eventosFiltrados: any = [];
  imgLargura = 50;
  imgMargem = 2;
  imgMostrar: boolean = false;

  private _termoBusca: string = "";

  constructor(private eventoService: EventoService) { }

  ngOnInit(): void {
    this.getEventos();
  }

  get termoBusca(): string {
    return this._termoBusca;
  }

  set termoBusca(value: string) {
    this._termoBusca = value;
    this.eventosFiltrados = this.termoBusca ? this.filtrarEventos(this.termoBusca) : this.eventos;
  }

  private getEventos(): void{
    this.eventoService.getEventos().subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos;
      },
      error => console.error(error)
    );
  }

  alterarVisibilidadeImagem(){
    this.imgMostrar = !this.imgMostrar;
  }

  filtrarEventos(termoBusca: string): any {
    termoBusca = termoBusca.toLowerCase();
    return this.eventos.filter(
            (ev: any) =>
                ev.tema.toLowerCase().indexOf(termoBusca) !== -1 ||
                ev.local.toLowerCase().indexOf(termoBusca) !== -1
          );
  }
}
