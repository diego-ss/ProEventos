import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss']
})
export class TituloComponent implements OnInit {

  @Input() titulo = "";
  @Input() subtitulo = "";
  @Input() iconClass = "fa fa-user";
  @Input() mostrarBotao = false;

  constructor() { }

  ngOnInit() {
  }

}
