import { Component, OnInit } from '@angular/core';
import { Picture } from '../models/picture.model';
import { PictureService } from '../services/picture.service';

@Component({
  selector: 'app-picture-gallery',
  templateUrl: './picture-gallery.component.html',
  styleUrl: './picture-gallery.component.scss'
})
export class PictureGalleryComponent implements OnInit {
  pictures: Picture[] = [];

  constructor(private pic: PictureService) { }

  ngOnInit(): void {
    this.loadPictures();
  }

  loadPictures() {
    this.pic.getAllPictures().subscribe({
      next: (pictures) => {
        this.pictures = pictures;
        console.log(pictures)
      },
      error: (err) => {
        console.error('Error loading types:', err);
      }
    });
  }
}