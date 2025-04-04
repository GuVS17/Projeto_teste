import { Component, Input, OnInit, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.css'],
  standalone: false
})
export class TituloComponent implements OnInit {

  @Input() titulo: string = '';

  constructor() { }

  ngOnInit() {
  }

}
