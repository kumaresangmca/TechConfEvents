import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SpeakerUpsertComponent } from './upsert.component';

describe('UpsertComponent', () => {
  let component: SpeakerUpsertComponent;
  let fixture: ComponentFixture<SpeakerUpsertComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SpeakerUpsertComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SpeakerUpsertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
