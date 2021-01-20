import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'rating-star',
  templateUrl: './rating-star.component.html',
  styleUrls: ['./rating-star.component.css']
})

export class RatingStarComponent implements OnInit {

  @Input() max: number;
  @Output() onRating = new EventEmitter<number>();
  @Input() setRating : number;
  public maxItem: any[];
  public ratedCount: number;
  
  constructor() {
    this.ratedCount = 0;
    
  }

  ngOnInit() {

    console.log(this.setRating);
    this.ratedCount = this.setRating;
    this.maxItem = [];
    for (let i = 0; i < this.max; i++) {
      this.maxItem.push(i + 1);
    }
  }

  public toggleRating(s: number): void {
    console.log(s);
    this.ratedCount = s;
    this.onRating.emit(this.ratedCount);
  }

}
