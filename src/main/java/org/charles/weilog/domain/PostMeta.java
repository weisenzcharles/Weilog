package org.charles.weilog.domain;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;

@Entity
public class PostMeta {
    @Id
    @GeneratedValue
    private Long id;
}
