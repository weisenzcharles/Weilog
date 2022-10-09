package org.charles.weilog.domain;

import lombok.Data;

import javax.persistence.*;

@Data

@Entity
@Table(name = "comment_meta")
public class CommentMeta {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    private Long commentId;

    private String mateKey;

    private String mateValue;
}