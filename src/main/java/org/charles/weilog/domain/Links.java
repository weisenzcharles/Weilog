package org.charles.weilog.domain;

import javax.persistence.*;
import java.util.Date;

@Entity
public class Links {
    @Id
    @GeneratedValue
    private Long id;

    private String title;
    private String url;
    private String description;
    private String image;
    private String target;
    private Boolean visible;
    private Long owner;
    private Integer rating;

    @Temporal(TemporalType.TIMESTAMP)
    private Date createdTime;
    @Temporal(TemporalType.TIMESTAMP)
    private Date modifiedTime;
}
