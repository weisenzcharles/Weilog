package org.charles.weilog.domain;


import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.experimental.Accessors;

import javax.persistence.*;

/**
 * 文章元数据。
 */
@Data
@Accessors(chain = true)
@NoArgsConstructor
@Entity
@Table(name = "post_meta")
public class PostMeta {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    // 文章 id
    private Long postId;

    private String mateKey;

    private String mateValue;
}