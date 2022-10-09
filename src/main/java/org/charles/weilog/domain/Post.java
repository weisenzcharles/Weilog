package org.charles.weilog.domain;

import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.experimental.Accessors;

import javax.persistence.*;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 * 文章。
 */
@Data
@Accessors(chain = true)
@NoArgsConstructor
@Entity
@Table(name = "posts")
public class Post {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String title;
    @Basic(fetch = FetchType.LAZY)
    @Lob
    private String content;
    // 文章摘要
    private String excerpt;
    // 分类 Id
    private Long taxonomyId;
    // 文章类型（post/page等）
    private Integer type;
    // 文章别名
    private String alias;
    // 点击数
    private Integer views;
    // 版权声明
    private String password;
    // 评论状态（open/closed）
    private boolean commentStatus;
    // 文章状态（publish/auto-draft/inherit等）
    private boolean status;
    // 是否推荐
    private boolean recommend;

    // private Integer userId;
    @ManyToMany(cascade = {CascadeType.PERSIST})
    private List<Attachment> attachments;
    @OneToOne(cascade = CascadeType.ALL)
    private User user;
    @ManyToMany(cascade = {CascadeType.PERSIST})
    private List<Tag> tags = new ArrayList<>();
    @ManyToMany(cascade = {CascadeType.PERSIST})
    private List<Comment> comments = new ArrayList<>();
    @Temporal(TemporalType.TIMESTAMP)
    private Date createdTime;
    @Temporal(TemporalType.TIMESTAMP)
    private Date modifiedTime;
}